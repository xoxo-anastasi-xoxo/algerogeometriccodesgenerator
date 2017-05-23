using System;
using System.Collections.Generic;
using Booler.Tokens;
using Booler.Exceptions;

namespace Booler
{
    /// <summary>
    /// Проверяет корректность следования токенов друг за другом и делит уравнение на 2 части: зависящую от переменных и свободную.
    /// </summary>
    public class Parser
    {
        // Константы, обозначающие тип предыдущего токена
        const int START = 0;
        const int AFTER_VARIABLEGROUP = 1;
        const int AFTER_OPERATION = 2;
        const int AFTER_EQUATION = 3;
        const int AFTER_SCALAR = 4;

        /// <summary>
        /// Проверка правильности порядка токенов и преобразование их в уравнение
        /// </summary>
        /// <param name="tokens">Список токенов</param>
        /// <param name="index">Номер уравнения в системе</param>
        /// <returns>Уравнение</returns>
        public Tuple<List<bool[]>, bool> Parse(List<Token> tokens, int index)
        {
            // Представление в памяти части уравнеия, содержащей переменные.
            List<bool[]> eq = new List<bool[]>();
            // Скаляр
            bool scalar=false;
            // Проверка на наличие в уравнении знака равенства и переменных.
            bool flag1 = false, flag2 = false;

            int state = START;

            foreach(Token token in tokens)
            {
                if(token.GetType() == typeof(VariableGroupToken))
                {
                    flag1 = true;
                    if (state != AFTER_OPERATION && state != START && state != AFTER_EQUATION)
                        throw new UnexpectedTokenException("Группа переменных может стоять только в начале, после знака равенства или сложения",  index);

                    eq.Add(((VariableGroupToken)token).variables);
                    state = AFTER_VARIABLEGROUP;
                }
                else if (token.GetType() == typeof(OperationToken))
                {
                    if (state != AFTER_VARIABLEGROUP && state != AFTER_SCALAR)
                        throw new UnexpectedTokenException("Знак сложения может стоять только после группы переменных или скаляра", index);

                    state = AFTER_OPERATION;
                }
                else if (token.GetType() == typeof(EquationToken))
                {
                    if (flag2) throw new ParserException("В уравнении допустимо исспользовать только один знак равенства", index);
                    flag2 = true;
                    if (state != AFTER_VARIABLEGROUP && state != AFTER_SCALAR)
                        throw new UnexpectedTokenException("Знак равенства может стоять только после скаляра или группы переменных", index);
                   
                    state = AFTER_EQUATION;
                }
                else if (token.GetType() == typeof(ScalarToken))
                {
                    if (state != AFTER_EQUATION  && state != START && state != AFTER_OPERATION)
                        throw new UnexpectedTokenException("Скаляр может стоять только в начале уравнения, после знака равенства или сложения", index);

                    scalar = !(((ScalarToken)token).variable.Equals(scalar));
                    state = AFTER_SCALAR;
                } else
                {
                    throw new UnexpectedTokenException($"Не ожидался токен {token.GetType()}", index);
                }
            }

            if (state == AFTER_EQUATION)
                throw new ParserException("Уравнение не должно заканчиваться знаком равенства!", index);
            if (!(flag1 && flag2)) throw new TokenizerException("Уравнение неполное!", index);

            return new Tuple<List<bool[]>, bool>(eq, scalar);
        }
    }
}
