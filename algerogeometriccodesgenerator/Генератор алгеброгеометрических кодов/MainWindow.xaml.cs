using System.Windows;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Точка вхада в программу.
        /// Конструктор главного окна MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Начало работы. Переход к выбору алгеброгеометрического кода.
        /// </summary>
        /// <param name="sender">MainWindow.</param>
        /// <param name="e">RoutedEventArgs.</param>
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            SelectCodeWindow win = new SelectCodeWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Переход к руководству оператора.
        /// </summary>
        /// <param name="sender">MainWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void fqButton_Click(object sender, RoutedEventArgs e)
        {
            FQWindow win = new FQWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Переход к информаци о разработчике програмыю
        /// </summary>
        /// <param name="sender">MainWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow win = new InfoWindow()
            {
                Top = this.Top,
                Left = this.Left

            };
            win.Show();
            this.Close();

        }

    }
}
