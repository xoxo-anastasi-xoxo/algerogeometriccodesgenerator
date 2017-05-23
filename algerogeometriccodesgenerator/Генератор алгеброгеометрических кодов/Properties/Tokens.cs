namespace Booler
{
    /// <summary>
    ///  Пространство, содержащее в себе все виды блоков(токенов), которые могут содержаться в исходных уравнениях.
    /// </summary>
    namespace Tokens
    {
        /// <summary>
        /// Общий вид искомых токенов.
        /// </summary>
        public class Token
        {
            public override string ToString()
            {
                return "Token.(Empty)";
            }
        }

        /// <summary>
        /// Токен-группа переменных, с промежуточным знаком умножения.
        /// </summary>
        class VariableGroupToken : Token
        {
            /// <summary>
            /// Массив, показывающий наличие или отсутствие каждой возможной для системы уравнений переменной в текущей группе.
            /// </summary>
            public readonly bool[] variables;
            /// <summary>
            /// Количество переменных в текущей группе.
            /// </summary>
            public readonly int size;

            /// <summary>
            /// Конструктор токена-группы переменных.
            /// </summary>
            /// <param name="variables"> Массив, показывающий наличие или отсутствие каждой возможной для системы уравнений переменной в текущей группе.</param>
            public VariableGroupToken(bool[] variables)
            {
                this.variables = variables;
                size = 0;
                for (int i = 0; i < variables.Length; i++)
                    if(variables[i])
                        size++;
            }
        }

        /// <summary>
        /// Токен-операция сложения.
        /// </summary>
        class OperationToken : Token
        {
            public override string ToString()
            {
                return "Tokens.Operation: +";
            }
        }

        /// <summary>
        /// Токен-знак равенства.
        /// </summary>
        class EquationToken : Token
        {
            public override string ToString()
            {
                return "Tokens.Equation: =";
            }
        }

        /// <summary>
        /// Токен-свободный член.
        /// </summary>
        class ScalarToken : Token
        {
            /// <summary>
            /// Значение свободного члена.
            /// </summary>
            public readonly bool variable;

            /// <summary>
            /// Конструктор токена-свободного члена.
            /// </summary>
            /// <param name="variable">Значение свободного члена</param>
            public ScalarToken(bool variable)
            {
                this.variable = variable;
            }

            public override string ToString()
            {
                return "Tokens.Scalar: " + variable.ToString();
            }
        }
    }
}
