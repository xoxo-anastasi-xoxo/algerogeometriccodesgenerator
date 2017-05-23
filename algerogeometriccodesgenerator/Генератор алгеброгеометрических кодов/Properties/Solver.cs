using System;
using System.Collections.Generic;
using Booler.Matrices;

namespace Booler
{
    /// <summary>
    /// Решает систкму уравнений.
    /// </summary>
    public class Solver
    {
       /// <summary>
       /// Матрица решений.
       /// </summary>
        SolutionsMatrix matrix;
        /// <summary>
        /// Проверочный лист.
        /// </summary>
        СheckList checkingList;

        /// <summary>
        /// Решает систему уравнений.
        /// </summary>
        /// <param name="equationsSystem">Система уравнений</param>
        /// <returns>Решение системы уравнений</returns>
        public SolutionsMatrix Solve(List<Equation> equationsSystem)
        {
            if (equationsSystem == null)
                throw new NullReferenceException("Система уравнений пуста!");
            if (equationsSystem.Count==0)
                throw new NullReferenceException("Введите систему уравнений!");

            matrix = new SolutionsMatrix();

            // Перебор всех возможных решений.
            for (int possibleSolution=0; possibleSolution<Math.Pow(2, equationsSystem[0].GroupSize); possibleSolution++)
            {
                // Представление номера возможного решения в двоичном виде.
               int[] intArrayPossibleSolution = MyStatics.ToBinaryIntArray(possibleSolution, equationsSystem[0].GroupSize);

                // Создание проверочного листа - элемента, помогающего определить принадлежит ли решение множеству решений данной системы.
                checkingList = new СheckList(equationsSystem);

                // Заполнение проверочного листа возможным решением.
                checkingList.FillingTheCheckList(intArrayPossibleSolution);

                /// Сверка значений полученного в результате подстановки решения в проверочный лист и значения, 
                /// которое должно быть по условию. 
                /// В случае полного совпадения решение, которое подставлялось в проверочный лист?
                /// добавляется в матрицу решений системы уравнений.
                if (checkingList.IsItRightSolution()) matrix.Matrix.Add(intArrayPossibleSolution);
            }
            return matrix;
        }
    }
}
