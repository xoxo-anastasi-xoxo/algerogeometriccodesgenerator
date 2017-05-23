using System.Windows;
using Booler;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для DescribtionWindow.xaml
    /// </summary>
    public partial class DescribtionWindow : Window
    {
        /// <summary>
        /// Конструктор окна DescribtionWindow.
        /// </summary>
        /// <param name="code">Алгеброгеометрический код</param>
        public DescribtionWindow(Code code)
        {
            InitializeComponent();
            K.Content = "Длина кодируемого слова - " + code.K;
            N.Content = "Длина кодового слова - " + code.N;
            T.Content = "Максимальное количество исправляемых ошибок - " + code.T;
        }
    }
}
