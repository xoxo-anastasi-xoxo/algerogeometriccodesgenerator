using System.Windows;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        /// <summary>
        /// Конструктор окнаинформации о разработчике.
        /// </summary>
        public InfoWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возврат к главному окну.
        /// </summary>
        /// <param name="sender">InfoWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void previousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }
    }
}
