using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace IncreasingSequenceCheck
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string input = sequenceTextBox.Text; // получаем значение из textBox
            int length = int.Parse(input); // конвертируем значение в int
            int[] numbers = new int[length]; // создаем массив
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            { // заполняем элементы массива случайными числами
                numbers[i] = rand.Next(1, 11);
            }
            massivTextBox.Text = string.Join(", ", numbers); // выводим заполненный массив на textBox2

            double[] sequence;
            try
            {
                sequence = sequenceTextBox.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
            catch (FormatException)
            {
                resultLabel.Content = "Некорректный ввод";
                return;
            }

            bool isIncreasing = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    isIncreasing = false;
                    break;
                } else
                {
                    isIncreasing = true;
                    break;
                }
            }
            resultLabel.Content = isIncreasing ? "Последовательность является возрастающей" : "Последовательность не является возростающей";
        }
    }
}