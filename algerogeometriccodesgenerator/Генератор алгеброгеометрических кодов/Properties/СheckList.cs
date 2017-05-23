using System;
using System.Collections.Generic;

namespace Booler
{
   /// <summary>
   /// Проверочный лист.
   /// </summary>
   public class СheckList
    {
        /// <summary>
        /// Результат подставления в систему уравнений конкретного решения. 
        /// </summary>
        bool[] checkingList;
        /// <summary>
        /// Система уравнений, которую будут проверять данным проверочным листом. 
        /// </summary>
        List<Equation> prototype=new List<Equation>();

        /// <summary>
        /// Возвращает значение уравнения с заданным индексом для заданной системы уравнений и заданного решения. 
        /// </summary>
        /// <param name="i">Номер уравнения</param>
        /// <returns>Результат подтавления в уравнение некоторого решения</returns>
        public bool this[int i]
        {
            get
            {
                if ((i < 0) || (i >= checkingList.Length))
                    throw new ArgumentOutOfRangeException("Индекс в проверочном листе", $"Индекс должен быть меньше {checkingList.Length} и больше или равен 0!");

                return checkingList[i];
            }
        }

        /// <summary>
        /// Создание проверочного листа на основе системы уравнений.
        /// </summary>
        /// <param name="prototype">Система уравнений, которую будут проверять данным проверочным листом</param>
        public СheckList(List<Equation> prototype)
        {
            if (prototype == null)
                throw new NullReferenceException("В проверочный лист в качестве прототипа подана пустая система уравнений!");

            this.prototype = prototype;

            checkingList = new bool[prototype.Count];
        }

        /// <summary>
        /// Заполняет проверочный лист для конкретного решения. 
        /// </summary>
        /// <param name="possibleSolution"></param>
        public void FillingTheCheckList(int[] possibleSolution)
        {
            // Просматриваем каждое уравнение.
            for (int equationNumber = 0; equationNumber < checkingList.Length; equationNumber++)
            {
                int firstHelper = 0;

                // Отдельно смотрим каждую группу переменных.
                for (int variableGroupNumber=0; variableGroupNumber<prototype[equationNumber].VariableTokenCount; variableGroupNumber++)
                {
                    int secondHelper = 1;

                    // Смотрим на наличие переменной в данной группе переменных.
                    for (int variableNumber = 0; variableNumber < prototype[equationNumber].GroupSize; variableNumber++)
                    {
                        if (prototype[equationNumber].Eq.Item1[variableGroupNumber][variableNumber])
                        {
                            secondHelper *= possibleSolution[variableNumber];
                            if (possibleSolution[variableNumber] == 0) break;
                        }

                    }
                    firstHelper = (firstHelper + secondHelper)%2;
                }
                checkingList[equationNumber] = (firstHelper == 1);
            }
        }

        /// <summary>
        /// Проверяет, совпадает ли правильный ответ к системе с полученным в проверочном листе. 
        /// </summary>
        /// <returns></returns>
        public bool IsItRightSolution()
        {
            if (this.checkingList == null)
                throw new NullReferenceException("Проверочный лист пуст!");
            if (this.prototype == null)
                throw new NullReferenceException("Матрица пуста!");

            for (int i = 0; i <checkingList.Length; i++)
            {
                if (checkingList[i] != prototype[i].Eq.Item2) return false;
            }
            return true;
        }
    }
}
