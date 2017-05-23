using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Booler;
using Booler.Exceptions;
using Booler.Matrices;
using System.Text.RegularExpressions;

namespace Генератор_алгеброгеометрических_кодов
{
    /// <summary>
    /// Логика взаимодействия для CodeGeneratingWindow.xaml
    /// </summary>
    public partial class CodeGeneratingWindow : Window
    {
        /// <summary>
        /// Количество переменных в системе уравнений.
        /// </summary>
        int groupSize = 0;
        /// <summary>
        /// Строковое представление системы уравнений.
        /// </summary>
        string line;
        /// <summary>
        /// Строковое представление уравнений.
        /// </summary>
        string[] lines;
        /// <summary>
        /// Система уравнений. 
        /// </summary>
        List<Equation> systemOfEquations = new List<Equation>();
        /// <summary>
        /// Инструмент для решения системы уравнений.
        /// </summary>
        Solver solver = new Solver();
        /// <summary>
        /// Матрица из решений системы уравнений.
        /// </summary>
        SolutionsMatrix theAnswer;
        /// <summary>
        /// Алгеброгеометрический код.
        /// </summary>
        Code AGCode;
        /// <summary>
        /// Индикатор наличия ошибки в системе уравнений.
        /// </summary>
        bool flag = true;
        /// <summary>
        /// Допустимые для ввода символы.
        /// </summary>
        private Regex regex = new Regex("[^x^0-9\\+\\=]+");
        /// <summary>
        /// Подсказка для ползователя.
        /// </summary>
        ToolTip t;


        /// <summary>
        /// Количество переменных в системе уравнений.
        /// </summary>
        public int GroupSize => groupSize;

        /// <summary>
        /// Конструктор окна CodeGeneratingWindow.
        /// </summary>
        public CodeGeneratingWindow()
        {
            InitializeComponent();
            t = new ToolTip();
            equations.ToolTip = t;
        }

        /// <summary>
        /// Заполняет поле groupSize.
        /// </summary>
        /// <param name="sender">CodeGeneratingWindow</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            groupSize = int.Parse(selectedItem.Content.ToString());
        }

        /// <summary>
        /// Генерирует алгеброгеометрический код.
        /// </summary>
        /// <param name="sender">CodeGeneratingWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void NextWindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                t.Content = "";
                if (groupSize == 0) throw new ArgumentNullException("количество переменных", "Невведено количество переменных!");
                /*
                                for (int i = 0; i < equations.Document.Blocks.Count; i++)
                                {
                                    equations.Document.Blocks.ElementAt<Block>(i).Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                                }
                */
                foreach (Block block in equations.Document.Blocks)
                    block.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

                #region Формирование системы уравнений в памяти
                line = new TextRange(equations.Document.ContentStart, equations.Document.ContentEnd).Text;
                lines = line.Split('\n');

                for (int i = 0; i < lines.Length; i++)
                {
                    try
                    {
                        if (i != lines.Length - 1) lines[i] = lines[i].Remove(lines[i].Length - 1, 1);
                        MyStatics.Reading(lines[i], groupSize, systemOfEquations, i);
                    }
                    catch (TokenizerException ex)
                    {
                        t.Content += (i+1) +" уравнение: "+ ex.Message + "\n";
                        equations.Document.Blocks.ElementAt<Block>(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
                        flag = false;
                    }
                    catch (ParserException ex)
                    {
                        t.Content += (i + 1) + " уравнение: " + ex.Message + "\n";
                        equations.Document.Blocks.ElementAt<Block>(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
                        flag = false;

                    }
                    catch (UnknownCodeMessageException ex)
                    {
                        t.Content += (i + 1) + " уравнение: " + ex.Message + "\n";
                        equations.Document.Blocks.ElementAt<Block>(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
                        flag = false;

                    }
                }
                #endregion

                if (flag)
                {
                    #region Решение системы уравнений
                    theAnswer = solver.Solve(systemOfEquations);
                    if (theAnswer.Matrix.Count == 0) throw new NullReferenceException("Система уравнений не имеет решений!");
                    #endregion

                    #region Формирование кода и вывод на экран его основных параметров
                    AGCode = new Code(theAnswer, lines);
                    
                    CodeDescriptionWindow win = new CodeDescriptionWindow(AGCode);
                    win.Top = this.Top;
                    win.Left = this.Left;
                    win.Show();
                    this.Close();
                    #endregion
                }
                flag = true;
            }
            catch (CodeGeneratingException ex)
            {
                t.Content = ex.Message;
                foreach (Block block in equations.Document.Blocks)
                    block.Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
               
            }
            catch (ArgumentNullException)
            {
                size.IsDropDownOpen = true;
            }
            catch (NullReferenceException ex)
            {
                t.Content += ex.Message;
                foreach (Block block in equations.Document.Blocks)
                    block.Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));

            }
            catch (TokenizerException ex)
            {
                t.Content += ex.Message + "\n";
                equations.Document.Blocks.ElementAt(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
            }
            catch (ParserException ex)
            {
                t.Content += ex.Message + "\n";
                equations.Document.Blocks.ElementAt(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
            }
            catch (UnknownCodeMessageException ex)
            {
                t.Content += ex.Message + "\n";
                equations.Document.Blocks.ElementAt(ex.Index).Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 21, 21));
            }
            finally
            {
                systemOfEquations = new List<Equation>();
            }
        }

        /// <summary>
        /// Возвращает на одно окно назад.
        /// </summary>
        /// <param name="sender">CodeGeneratingWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void PreviousWindowButton_Click(object sender, RoutedEventArgs e)
        {
            SelectCodeWindow win = new SelectCodeWindow();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Вызывает справку.
        /// </summary>
        /// <param name="sender">CodeGeneratingWindow</param>
        /// <param name="e">RoutedEventArgs</param>
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow win = new RulesWindow();
            win.Top = this.Top + 50;
            win.Left = this.Left + 50;
            win.ShowDialog();
        }

        /// <summary>
        /// Проверяют допустимость символа, который вводится.
        /// </summary>
        /// <param name="sender">CodeGeneratingWindow</param>
        /// <param name="e">TextCompositionEventArgs</param>
        private void Equations_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
