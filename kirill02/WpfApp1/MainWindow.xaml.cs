using System;
using System.Linq;
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
            string sequenceText = sequenceTextBox.Text;
            if (string.IsNullOrWhiteSpace(sequenceText))
            {
                resultLabel.Content = "Пустая последовательность";
                return;
            }

            double[] sequence;
            try
            {
                sequence = sequenceText.Split(' ').Select(double.Parse).ToArray();
            }
            catch (FormatException)
            {
                resultLabel.Content = "Некорректный ввод";
                return;
            }

            bool isIncreasing = true;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] >= sequence[i + 1])
                {
                    isIncreasing = false;
                    break;
                }
            }

            resultLabel.Content = isIncreasing ? "Последовательность возрастающая" : "Последовательность не является возрастающей";
        }
    }
}