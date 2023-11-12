using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace DA_Lab_4
{
    public static class DataLoader
    {
        public static (List<double> x, List<double> y)? LoadValues(bool dependent)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Усі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    return dependent 
                        ? ReadDependentNumbersFromFile(filePath)
                        : ReadIndependentNumbersFromFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при читанні файлу: {ex.Message}");
                }
            }

            return null;
        }

        private static (List<double> x, List<double> y)? ReadDependentNumbersFromFile(string filePath)
        {
            var resultX = new List<double>();
            var resultY = new List<double>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length != 2)
                        throw new FileFormatException($"Кожний рядок має містити 2 числа, розділені комою, а містив: {line}");

                    var modifiedFirstToken = tokens[0].Replace('.', ',');
                    var modifiedSecondToken = tokens[1].Replace('.', ',');

                    if (double.TryParse(modifiedFirstToken, out double x))
                        resultX.Add(x);
                    else
                        MessageBox.Show($"Помилка при зчитуванні числа!");

                    if (double.TryParse(modifiedSecondToken, out double y))
                        resultY.Add(y);
                    else
                        MessageBox.Show($"Помилка при зчитуванні числа!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при зчитуванні файлу: {ex.Message}");
            }

            return (resultX, resultY);
        }

        private static (List<double> x, List<double> y)? ReadIndependentNumbersFromFile(string filePath)
        {
            var resultX = new List<double>();
            var resultY = new List<double>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length != 2)
                        throw new FileFormatException($"Кожний рядок має містити 2 числа, розділені комою, а містив: {line}");

                    var modifiedFirstToken = tokens[0].Replace('.', ',');
                    var modifiedSecondToken = tokens[1].Replace('.', ',');

                    var xParseResult = double.TryParse(modifiedFirstToken, out double number);
                    var yParseResult = int.TryParse(modifiedSecondToken, out int datasetIndex);

                    if (!xParseResult || !yParseResult || (datasetIndex != 0 && datasetIndex != 1))
                    {
                        MessageBox.Show($"Помилка при зчитуванні числа {modifiedFirstToken}!");
                        continue;
                    }
                    else
                    {
                        if (datasetIndex == 0) 
                            resultX.Add(number);
                        else
                            resultY.Add(number);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при зчитуванні файлу: {ex.Message}");
            }

            return (resultX, resultY);
        }
    }
}
