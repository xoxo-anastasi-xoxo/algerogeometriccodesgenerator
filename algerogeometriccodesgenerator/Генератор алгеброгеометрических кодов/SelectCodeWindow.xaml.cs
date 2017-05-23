using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.Serialization.Formatters.Binary;
using Booler;
using System.IO;
using System;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для SelectCodeWindow.xaml
    /// </summary>
    public partial class SelectCodeWindow : Window
    {
        /// <summary>
        /// Инструмент бинарной сериализации.
        /// </summary>
        BinaryFormatter formatter = new BinaryFormatter();
        /// <summary>
        /// Список сохраненных кодов.
        /// </summary>
        List<Code> codes = new List<Code>();
        /// <summary>
        /// Имя выбранного элемента codeSelector.
        /// </summary>
        string itemName;

        /// <summary>
        /// Канструктор окна SelectCodeWindow.
        /// </summary>
        public SelectCodeWindow()
        {
            InitializeComponent();
            try
            {
                using (FileStream fs = new FileStream("SavedCodes.nk", FileMode.Open))
                {
                    while (fs.Position < fs.Length)
                    {
                        Code newCode = (Code)formatter.Deserialize(fs);
                        codes.Add(newCode);
                    }
                }
            }
            catch (Exception)
            {

            }
            CreateComboBox();
        }

        /// <summary>
        /// Открывает предыдущее окно.
        /// </summary>
        /// <param name="sender">SelectCodeWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void previousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Готовит код к возможному удалению.
        /// </summary>
        /// <param name="sender">SelectCodeWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void trashButton_Click(object sender, RoutedEventArgs e)
        {
            if ((codeSelector.SelectedIndex >= 0) && (codeSelector.SelectedIndex < codes.Count))
            {
                СhoiceWindow win2 = new СhoiceWindow(itemName, codeSelector.SelectedIndex, codes, this);
                win2.Top = this.Top+130;
                win2.Left = this.Left+180;
                win2.ShowDialog();
            }
        }

        /// <summary>
        /// Переходит к окну с характеристиками выбранного кода или к окну для создания нового кода.
        /// </summary>
        /// <param name="sender">SelectCodeWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void nextWindowButton_Click(object sender, RoutedEventArgs e)
        {

            if ((codeSelector.SelectedIndex >= 0) && (codeSelector.SelectedIndex < codes.Count))
            {
                CodeDescriptionWindow win2 = new CodeDescriptionWindow(codes[codeSelector.SelectedIndex]);
                win2.Top = this.Top;
                win2.Left = this.Left;
                win2.Show();
                this.Close();
            }
            else
            if (itemName == "Cоздать новый код...")
            {
                CodeGeneratingWindow win2 = new CodeGeneratingWindow();
                win2.Top = this.Top;
                win2.Left = this.Left;
                win2.Show();
                this.Close();
            }
            else
            {
                codeSelector.IsDropDownOpen = true;
            }
        }

        /// <summary>
        /// Переписывает текст codeSelector.
        /// </summary>
        public void CreateComboBox()
        {

            ComboBoxItem newItem = new ComboBoxItem();
            codeSelector.Items.Clear();
            for (int i = 0; i < codes.Count; i++)
            {
                newItem = new ComboBoxItem();
                newItem.Content = codes[i].ToString();
                newItem.Height = 22;
                newItem.Width = 191;
                newItem.FontSize = 13;
                newItem.BorderBrush = null;
                newItem.Foreground = new SolidColorBrush(Color.FromArgb(255, 12, 26, 62));
                newItem.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                newItem.Margin = new Thickness(0, 0, 0, 0);
                newItem.ToolTip = new ToolTip { Content = $"Длина исходного кодируемого слова - {codes[i].K}\nДлина кодового слова - {codes[i].N} \nМаксимальное количество исправляемых ошибок - {codes[i].T}" };
                codeSelector.Items.Add(newItem);

            }

            newItem = new ComboBoxItem();
            newItem.Content = "Cоздать новый код...";
            newItem.Height = 22;
            newItem.Width = 191;
            newItem.FontSize = 13;
            newItem.BorderBrush = null;
            newItem.Foreground = new SolidColorBrush(Color.FromArgb(255, 12, 26, 62));
            newItem.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            newItem.Margin = new Thickness(0, 0, 6, 0);

            codeSelector.Items.Add(newItem);
        }

        /// <summary>
        /// Отмечает, какой код выбран, или открывает окно для создания нового кода.
        /// </summary>
        /// <param name="sender">SelectCodeWindow</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void codeSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem!=null) itemName = selectedItem.Content.ToString();

            if (itemName == "Cоздать новый код...")
            {
                CodeGeneratingWindow win2 = new CodeGeneratingWindow();
                win2.Top = this.Top;
                win2.Left = this.Left;
                win2.Show();
                this.Close();
            }
        }
    }
}