using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Booler;
using Booler.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для CodeWindow.xaml
    /// </summary>
    public partial class CodeWindow : Window
    {
        /// <summary>
        /// Выбранный код.
        /// </summary>
        Code AGCode;
        /// <summary>
        /// Указываетна выбор операции.
        /// </summary>
        bool flag;
        /// <summary>
        /// Допустимые для ввода символы.
        /// </summary>
        Regex regex = new Regex("[^0-1]+");

        /// <summary>
        /// Конструктор окна CodeWindow.
        /// </summary>
        /// <param name="AGCode">Выбранный код</param>
        public CodeWindow(Code AGCode)
        {
            this.AGCode = AGCode;
            InitializeComponent();
            first.MaxLength = AGCode.K;
            flag = true;
            ToolTip t = new ToolTip()
            {
                Content = "Длина кодируемого слова - " + AGCode.K + "\nДлина кодового слова - "
                + AGCode.N + "\nМаксимальное количество исправляемых ошибок - " + AGCode.T
            };
            helpButton.ToolTip = t;
        }


        /// <summary>
        /// Возвращает к предыдущем окну.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PreviousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CodeDescriptionWindow win = new CodeDescriptionWindow(AGCode);
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Кодирует или декодирует сообщение.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void CodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                if (first.Text.Length != AGCode.K)
                {
                    error.Visibility = Visibility.Visible;
                    error.Text = $"   Длина кодируемого слова должна равняться {AGCode.K}.";
                    return;
                }
                try
                {
                    int[] ourMessage = MyStatics.ToIntArray(first.Text, AGCode.K);
                    int[] ourCodeMessage = AGCode.Encode(ourMessage);
                    second.Text = "";

                    for (int i = 0; i < ourCodeMessage.Length; i++) second.Text += ourCodeMessage[i];
                }
                catch (Exception ex)
                {
                    error.Visibility = Visibility.Visible;
                    error.Text = ex.Message;
                }
            }
            else
            {
                if (first.Text.Length != AGCode.N)
                {
                    error.Visibility = Visibility.Visible;
                    error.Text = $"Длина кодового слова должна равняться {AGCode.N}.";
                    return;
                }


                try
                {
                    int[] ourDecodedMessage;
                    int[] ourMessage = MyStatics.ToIntArray(first.Text, AGCode.N);
                    ourDecodedMessage = AGCode.Decode(ourMessage);
                    second.Text = "";
                    for (int i = 0; i < ourDecodedMessage.Length; i++) second.Text += ourDecodedMessage[i];
                }
                catch (MistakesNumberException ex)
                {
                    error.Visibility = Visibility.Visible;
                    error.Text = ex.Message;
                    return;
                }
                catch (Exception ex)
                {
                    error.Visibility = Visibility.Visible;
                    error.Text = ex.Message;
                }

            }
        }

        /// <summary>
        /// Переключает режим кодирования.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void CodeOrDecodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if ((selectedItem.Content.ToString()) == "Кодирование")
            {
                first.Text = "";
                second.Text = "";
                first.MaxLength = AGCode.K;
                flag = true;
            }

            if ((selectedItem.Content.ToString()) == "Декодирование")
            {
                first.Text = "";
                second.Text = "";
                first.MaxLength = AGCode.N;
                flag = false;
            }
        }

        /// <summary>
        /// Синхронизирует работу полей для кодового и кодируемого сообщения.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">TextChangedEventArgs</param>
        private void First_TextChanged(object sender, TextChangedEventArgs e)
        {
            second.Text = "";
            error.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Запрещает ввод пробелов.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">KeyEventArgs</param>
        private void FirstPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.Space);
            if (e.Key == Key.Return)
            {
                CodeButton_Click(this, new RoutedEventArgs());
            }
        }

        /// <summary>
        /// Проверяет допустимость вводимых символов. Допускает ввод только 0 и 1.
        /// </summary>
        /// <param name="sender">CodeWindow</param>
        /// <param name="e">TextCompositionEventArgs</param>
        private void First_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            DescribtionWindow win = new DescribtionWindow(AGCode);
            win.Top = this.Top + 100;
            win.Left = this.Left + 140;
            win.ShowDialog();
        }
    }

}
