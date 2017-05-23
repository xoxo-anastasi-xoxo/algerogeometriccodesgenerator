using System;
using System.Collections.Generic;

namespace Booler
{
    /// <summary>
    /// Матрицы, используемые для решения поставленной задачи.
    /// </summary>
    namespace Matrices
    {
        /// <summary>
        /// Матрица
        /// </summary>
        [Serializable]
        public class BaseMatrix
        {
            /// <summary>
            /// Матрица
            /// </summary>
            List<int[]> matrix;

            /// <summary>
            /// Матрица
            /// </summary>
            public List<int[]> Matrix => matrix;

            /// <summary>
            /// Обращается к элементу матрицы.
            /// </summary>
            /// <param name="i">Номер столбца</param>
            /// <param name="j">Номер строки</param>
            /// <returns></returns>
            public int this[int i, int j]
            {
                get
                {
                    if ((i < 0) || (i >= Matrix.Count) || (j < 0) || (j >= Matrix[0].Length))
                        throw new ArgumentOutOfRangeException("Index of matrix's coordinates", $"Use valid int");
                    return Matrix[i][j];
                }
            }

            /// <summary>
            /// Конструктор пустой матрицы.
            /// </summary>
            public BaseMatrix()
            {
                matrix = new List<int[]>();
            }

            public BaseMatrix(int[] ourLine) : this()
            {
                for (int i = 0; i < ourLine.Length; i++)
                {
                    int[] nextLine = { ourLine[i] };
                    matrix.Add(nextLine);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Матрицу в строковом формате</returns>
            public override string ToString()
            {
                if (matrix.Count == 0)
                    throw new NullReferenceException("Matrix, that you have tried bring to string, is empty!");

                string str = "";
                for (int i = 0; i < matrix[0].Length; str += "\n", i++)
                    for (int j = 0; j < matrix.Count; j++)
                        str += $" {matrix[j][i]}";

                return str;
            }
        }

        /// <summary>
        /// Матрица решений системы уравнений.
        /// </summary>
        [Serializable]
        public class SolutionsMatrix : BaseMatrix
        {
            /// <summary>
            /// Матрица решений системы уравнений.
            /// </summary>
            public SolutionsMatrix() : base() { }
        }
    }
}
