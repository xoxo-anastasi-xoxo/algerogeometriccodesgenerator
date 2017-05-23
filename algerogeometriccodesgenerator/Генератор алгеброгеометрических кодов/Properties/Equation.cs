using System;
using System.Collections.Generic;
using Booler.Tokens;

namespace Booler
{
    /// <summary>
    /// Уравнение.
    /// </summary>
    public class Equation
    {
        /// <summary>
        /// Разбивает строку на токены, характерные для уравнений.
        /// </summary>
        Tokenizer tokenizer;
        /// <summary>
        /// Проверяет возможно ли разбиение строки на токены.
        /// </summary>
        Parser parser = new Parser();

        /// <summary>
        /// Максимальное количество переменных в уравнении.
        /// </summary>
        int groupSize;
        /// <summary>
        /// Уравнение в памяти.
        /// </summary>
        List<Token> tokens = null;
        /// <summary>
        /// Уравнение.
        /// </summary>
        Tuple<List<bool[]>, bool> eq = null;

        /// <summary>
        /// Уравнение.
        /// </summary>
        public Tuple<List<bool[]>, bool> Eq => eq;
        /// <summary>
        /// Максимальное количество переменных в уравнении.
        /// </summary>
        public int GroupSize => groupSize;
        /// <summary>
        /// Количество слагаемых в уравнении.
        /// </summary>
        public int VariableTokenCount => eq.Item1.Count;

        /// <summary>
        /// Строит в памяти уравнение из полученной строки.
        /// </summary>
        /// <param name="input">Строка, содержащая уравнение</param>
        /// <param name="groupSize">Максимальное количество переменных в этой строке</param>
        /// <param name="index">Номер уравнения в системе.</param>
        public Equation(string input, int groupSize, int index)
        {
            this.groupSize = groupSize;
            tokenizer = new Tokenizer(groupSize);
            tokens = tokenizer.SplitToTokens(input, index);
            eq = parser.Parse(tokens, index);
        }
    }
}
