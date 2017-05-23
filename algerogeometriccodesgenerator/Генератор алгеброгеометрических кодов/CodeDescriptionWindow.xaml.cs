using System.Windows;
using System.Windows.Documents;
using Booler;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для CodeDescriptionWindow.xaml
    /// </summary>
    public partial class CodeDescriptionWindow : Window
    {
        /// <summary>
        /// Выбранный код.
        /// </summary>
        Code AGCode;
        /// <summary>
        /// Инструмент для бинарной сериализации.
        /// </summary>
        BinaryFormatter formatter = new BinaryFormatter();

        /// <summary>
        /// Конструктор окна CodeDescriptionWindow.
        /// </summary>
        /// <param name="AGCode">Выбранный код</param>
        public CodeDescriptionWindow(Code AGCode)
        {
            InitializeComponent();
            this.AGCode = AGCode;
            infoTextBox.Width = infoTextBox.FontSize * AGCode.N * 1.25;
            infoTextBox.Text = "Длина кодируемых слов - " + AGCode.K;
            infoTextBox.Text += "\nДлина кодовых слов - " + AGCode.N;
            infoTextBox.Text += "\nМаксимальное количество ошибок - " + AGCode.T;
            infoTextBox.Text += "\n\nПорождающая матрица:\n";
            infoTextBox.Text += (AGCode.GeneratingMatrix.ToString());
        }

        /// <summary>
        /// Возвращается к предыдущему окну.
        /// </summary>
        /// <param name="sender">CodeDescriptionWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PreviousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CodeGeneratingWindow win = new CodeGeneratingWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.equations.Document.Blocks.Clear();
            for (int i = 0; i < AGCode.SystemOfEquations.Length; i++)
                win.equations.Document.Blocks.Add(new Paragraph(new Run(AGCode.SystemOfEquations[i])));
            win.size.SelectedIndex = AGCode.K - 1;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Открывает следующее окно.
        /// </summary>
        /// <param name="sender">CodeDescriptionWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void NextWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CodeWindow win = new CodeWindow(AGCode);
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Выполняет сохранение полученного кода.
        /// </summary>
        /// <param name="sender">CodeDescriptionWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("SavedCodes.nk", FileMode.Open))
                {
                    fs.Seek(0, SeekOrigin.End);
                    formatter.Serialize(fs, AGCode);
                }
            }
            catch (FileNotFoundException)
            {
                using (FileStream fs = new FileStream("SavedCodes.nk", FileMode.Create))
                {
                    fs.Seek(0, SeekOrigin.End);
                    formatter.Serialize(fs, AGCode);
                }
            }
            catch (Exception)
            {

            }
            littleTextBlock.Text = "Сохранено!";
        }

    }
}
