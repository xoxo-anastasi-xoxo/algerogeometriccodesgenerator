using System.Collections.Generic;
using System.Windows;
using Booler;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для СhoiceWindow.xaml
    /// </summary>
    public partial class СhoiceWindow : Window
    {
        /// <summary>
        /// Инструмент для бинарной сериализации.
        /// </summary>
        BinaryFormatter formatter = new BinaryFormatter();
        /// <summary>
        /// Номер кода в списке сохраненных.
        /// </summary>
        int index;
        /// <summary>
        /// Выбранный код.
        /// </summary>
        List<Code> codes;
        /// <summary>
        /// Окно, вызвавшее конструктор СhoiceWindow.
        /// </summary>
        SelectCodeWindow win;

        /// <summary>
        /// Конструктор окна СhoiceWindow.
        /// </summary>
        /// <param name="name">Название кода</param>
        /// <param name="index">Номер кода в списке сохраненных</param>
        /// <param name="codes">Выбранный код</param>
        /// <param name="win">Окно, вызвавшее конструктор СhoiceWindow</param>
        public СhoiceWindow(string name, int index, List<Code> codes, SelectCodeWindow win)
        {
            InitializeComponent();

            label.Content = "Вы уверены, что хотите \nудалить " + name + "?";
            this.index = index;
            this.codes = codes;
            this.win = win;
        }

        /// <summary>
        /// Удаляет выбранный код.
        /// </summary>
        /// <param name="sender">СhoiceWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if ((index >= 0) && (index < codes.Count))
            {
                using (FileStream fs = new FileStream("SavedCodes.nk", FileMode.Create))
                {
                    codes.Remove(codes[index]);
                    foreach (Code c in codes)
                        formatter.Serialize(fs, c);
                }
                win.CreateComboBox();
            }
            this.Close();
        }

        /// <summary>
        /// Закрывает окно.
        /// </summary>
        /// <param name="sender">СhoiceWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
