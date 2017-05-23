using System.Windows;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class FQWindow : Window
    {
        /// <summary>
        /// Конструктор окна полной справки
        /// </summary>
        public FQWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает к предыдущему окну.
        /// </summary>
        /// <param name="sender">FQWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PreviousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow()
            {
                Top = this.Top,
                Left = this.Left
            };
            win.Show();
            this.Close();
        }
    }
}
