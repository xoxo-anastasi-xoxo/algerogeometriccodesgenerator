using System;
using Booler.Tokens;
using Booler.Exceptions;
using System.Collections.Generic;

namespace Booler
{
    /// <summary>
    /// Производит деление входной строки на токены, если это возможно.
    /// </summary>
    public class Tokenizer
    {
        /// <summary>
        /// Количество различных переменных в системе уравнений.
        /// </summary>
        public readonly int group_size;

        public Tokenizer(int group_size)
        {
            this.group_size = group_size;
        }

        /// <summary>
        /// Разбивает строку на токены, характерные для уравнений.
        /// </summary>
        /// <param name="input">Исходная строка, поданная пользователем. </param>
        ///  <param name="mainIndex">Номер уравнения всистеме.</param>
        /// <returns>Список токенов.</returns>
        public List<Token> SplitToTokens(string input, int mainIndex)
        {
            List<Token> tokens = new List<Token>();

            for (int i = 0; i < input.Length;)
            {
                switch (input[i])
                {
                    case ' ':
                        i++;
                        break;
                    case 'x':
                        bool[] vars = new bool[group_size];
                        while (true)
                        {
                            if (i >= input.Length || input[i] != 'x')
                                break;

                            int j;
                            for (j = i + 1; j < input.Length && Char.IsDigit(input[j]); j++) ;
                            if (j == (i + 1))
                            {
                                throw new VariableGroupTokenException("Ожидался индекс при переменной.", mainIndex);
                            }

                            int index;
                            int.TryParse(input.Substring(i + 1, j - i - 1), out index);
                            index--;

                            if (index < 0 || index >= group_size)
                            {
                                throw new VariableGroupTokenException("Индекс выходит за границыдопустимых значений.", mainIndex);
                            }

                            vars[index] = true;

                            for (; j < input.Length && input[j] == ' '; j++) ;
                            i = j;
                        }

                        tokens.Add(new VariableGroupToken(vars));
                        break;
                    case '+':
                        tokens.Add(new OperationToken());
                        i++;
                        break;
                    case '=':
                        i++;
                        tokens.Add(new EquationToken());
                        break;
                    case '0':
                        i++;
                        tokens.Add(new ScalarToken(false));
                        break;
                    case '1':
                        i++;
                        tokens.Add(new ScalarToken(true));
                        break;
                    default:
                        throw new UnexpectedSymbolException($"Неизвестный символ '{input[i]}'", mainIndex);
                        break;
                }
            }
            return tokens;
        }
    }
}
