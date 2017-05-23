using System;
using Booler.Matrices;
using Booler.Exceptions;

namespace Booler
{
    /// <summary>
    /// Алгеброгеометрический код.
    /// </summary>
    [Serializable]
    public class Code
    {
        /// <summary>
        /// Порождающая матрица кода.
        /// </summary>
        SolutionsMatrix generatingMatrix;
        /// <summary>
        /// Матрица всех возможных кодовых слов.
        /// </summary>
        BaseMatrix allCodeWords;
        /// <summary>
        /// Максимальное количество исправляемых ошибок.
        /// </summary>
        int t;
        /// <summary>
        /// Система уравнений, порождающая данный код.
        /// </summary>
        string[] systemOfEquations;

        /// <summary>
        /// Порождающая матрица кода.
        /// </summary>
        public SolutionsMatrix GeneratingMatrix => generatingMatrix;
        /// <summary>
        /// Матрица всех возможных кодовых слов.
        /// </summary>
        public BaseMatrix AllCodeWords => allCodeWords;
        /// <summary>
        /// Длина кодируемого слова.
        /// </summary>
        public int K => generatingMatrix.Matrix[0].Length;
        /// <summary>
        /// Длина кодового слова.
        /// </summary>
        public int N => generatingMatrix.Matrix.Count;
        /// <summary>
        /// Максимальное количество исправляемых ошибок.
        /// </summary>
        public int T => t;
        /// <summary>
        /// Система уравнений, порождающая данный код.
        /// </summary>
        public string[] SystemOfEquations => systemOfEquations;

        /// <summary>
        /// Создает код на основе полученной матрицы, устонавливая его основные параметры.
        /// </summary>
        /// <param name="generatingMatrix">Порождающая матрица</param>
        /// <param name="line">Система уравнений, порождающая код</param>
        public Code(SolutionsMatrix generatingMatrix, string[] line)
        {
            if (generatingMatrix.Matrix.Count < generatingMatrix.Matrix[0].Length) throw new CodeGeneratingException("Система имеет недостаточно решений для генерации кода.");

            this.generatingMatrix = generatingMatrix;
            systemOfEquations = line;
            allCodeWords = new BaseMatrix();
            for (int possibleCodeNumber = 0; possibleCodeNumber < Math.Pow(2, K); possibleCodeNumber++)
            {
                int[] intArrayPossibleCodeNumber = MyStatics.ToBinaryIntArray(possibleCodeNumber, K);
                BaseMatrix vectorPossibleCodeNumber = new BaseMatrix();
                for (int i = 0; i < K; i++)
                {
                    int[] nextLine = { intArrayPossibleCodeNumber[i] };
                    vectorPossibleCodeNumber.Matrix.Add(nextLine);
                }
                BaseMatrix vectorPossibleCode = MyStatics.Multiplication(vectorPossibleCodeNumber, generatingMatrix);
                allCodeWords.Matrix.Add(vectorPossibleCode.Matrix[0]);
            }

            this.t = (MyStatics.FindMinDistance(AllCodeWords) - 1) / 2;
        }

        /// <summary>
        /// Кодирует полученное сообщение. 
        /// </summary>
        /// <param name="ourMessage">Кодируемое слово</param>
        /// <returns>Код</returns>
        public int[] Encode(int[] ourMessage)
        {
            BaseMatrix A = new BaseMatrix(ourMessage);
            BaseMatrix C = MyStatics.Multiplication(A, generatingMatrix); ;
            return C.Matrix[0];
        }

        /// <summary>
        /// Декодирует полученное сообщение, исправляя ошибки.
        /// </summary>
        /// <param name="ourMessage">Декодируемое слово</param>
        /// <returns>Исходное сообщение</returns>
        public int[] Decode(int[] ourMessage)
        {
            int currentDistance = 0, minDistance = N + 1, number = 0;

            // Совершаем проход по всем возможным кодовым словам.
            for (int i = 0; i < allCodeWords.Matrix.Count; i++)
            {
                for (int j = 0; j < allCodeWords.Matrix[i].Length; j++)
                    if (ourMessage[j] != allCodeWords.Matrix[i][j]) currentDistance++;
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    number = i;
                }
                currentDistance = 0;
                if (minDistance == 0) return MyStatics.ToBinaryIntArray(number, K);
            }
            if (minDistance > T)
                throw new MistakesNumberException($"Количество ошибок, сделанных в кодовом слове, превышено на {minDistance-T}!");
            return MyStatics.ToBinaryIntArray(number, K);
        }

        /// <summary>
        /// Формирует имя кода в соответствии с основными характеристиками.
        /// </summary>
        /// <returns>Имя кода</returns>
        public override string ToString()
        {
            return $"Код[{K},{N},{T}]";
        }
    }
}
