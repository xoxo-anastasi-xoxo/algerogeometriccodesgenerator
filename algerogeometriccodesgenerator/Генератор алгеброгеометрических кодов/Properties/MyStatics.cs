using System;
using System.Collections.Generic;
using Booler.Matrices;

namespace Booler
{
    /// <summary>
    /// Статические методы, потребовавшиеся в ходе решения задачи.
    /// </summary>
    public static class MyStatics
    {
        /// <summary>
        /// Представляет число в двоичном виде.
        /// </summary>
        /// <param name="value">Число в десятичной системе</param>
        /// <param name="size">Размерность двоичного представления числа</param>
        /// <returns>Число в двоичной системе</returns>
        public static int[] ToBinaryIntArray(int value, int size)
        {
            int[] intBinaryCode = new int[size];
            string binaryCode = Convert.ToString(value, 2);

            if ((binaryCode.Length > size) || (value < 0))
                throw new ArgumentOutOfRangeException("Размерность двоичного представления числа",
                   $"Размерность двоичного представления числа должна быть 0<=N<{Math.Pow(2, size)}.");

            // Заполнение массива ведущими нулями.
            for (int i = 0; i < size - binaryCode.Length; i++) intBinaryCode[i] = 0;
            for (int i = size - binaryCode.Length; i < size; i++) intBinaryCode[i] = (int)binaryCode[i - size + binaryCode.Length] - 48;
            return intBinaryCode;
        }

        /// <summary>
        /// Перемножает матрицы.
        /// </summary>
        /// <param name="A">Первый множитель</param>
        /// <param name="B">Второй множитель</param>
        /// <returns></returns>
        public static BaseMatrix Multiplication(BaseMatrix A, BaseMatrix B)
        {
            if ((A.Matrix.Count == 0) || (B.Matrix.Count == 0) || (A == null) || (B == null))
                throw new NullReferenceException("You tried multiplicate empty matrix!");
            if (B.Matrix[0].Length != A.Matrix.Count)
                throw new ArgumentException("Matrices are incompatible for multiplication!");

            BaseMatrix C = new BaseMatrix();

            for (int i = 0; i < A.Matrix[0].Length; i++)
            {
                int[] helper = new int[B.Matrix.Count];

                for (int j = 0; j < B.Matrix.Count; j++)
                {

                    for (int k = 0; k < A.Matrix.Count; k++)
                        helper[j] += A.Matrix[k][i] * B.Matrix[j][k];
                    helper[j] %= 2;
                }
                C.Matrix.Add(helper);
            }

            return C;
        }

        /// <summary>
        /// Преобразует строковое сообщение в массив
        /// </summary>
        /// <param name="input">Исходное сообщение</param>
        /// <param name="size">Размер сообщения</param>
        /// <returns>Исходное сообщение</returns>
        public static int[] ToIntArray(string input, int size)
        {
            int[] output = new int[size];

            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] != '0') && (input[i] != '1')) throw new ArgumentException("Возможно использование только символов 0 и 1!");
                output[i] = input[i] - (int)'0';
            }
            for (int i = input.Length; i < size; i++) output[i] = 0;
            return output;
        }

        /// <summary>
        /// Ищет минимальное расстояние в коде.
        /// </summary>
        /// <param name="allCodeWords">Множество всех кодовых слов</param>
        /// <returns>Минимальное расстояние</returns>
        public static int FindMinDistance(BaseMatrix allCodeWords)
        {
            int minDistance = Int32.MaxValue, currentDistance = 0;
            for (int i = 0; i < allCodeWords.Matrix.Count; i++)
            {
                for (int j = i + 1; j < allCodeWords.Matrix.Count; j++)
                {
                    for (int k = 0; k < allCodeWords.Matrix[0].Length; k++)
                        currentDistance += (allCodeWords.Matrix[i][k] + allCodeWords.Matrix[j][k]) % 2;
                    if (currentDistance < minDistance) minDistance = currentDistance;
                    currentDistance = 0;
                }
            }
            return minDistance;
        }

        /// <summary>
        /// Считывает уравнение и добавляет его в систему уравнениц.
        /// </summary>
        /// <param name="input">Строковое представление системы  уравнений</param>
        /// <param name="groupSize">Количество переменных всистеме уравнений</param>
        /// <param name="systemOfEquations">Система уравнений</param>
        /// <param name="index">Порядковый номер уравнения в системе</param>
        public static void Reading(string input, int groupSize, List<Equation> systemOfEquations, int index)
        {
            if (input != "")
                systemOfEquations.Add(new Equation(input, groupSize, index));
        }
    }
}
