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
        public static List<(double x, double y)>? LoadValues()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Усі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    return ReadNumbersFromFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при читанні файлу: {ex.Message}");
                }
            }

            return null;
        }

        private static List<(double x, double y)> ReadNumbersFromFile(string filePath)
        {
            var result = new List<(double x, double y)>();

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

                    if (double.TryParse(modifiedFirstToken, out double x) && 
                        double.TryParse(modifiedSecondToken, out double y))
                        result.Add((x, y));
                    else
                        MessageBox.Show($"Помилка при зчитуванні числа!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при зчитуванні файлу: {ex.Message}");
            }

            return result;
        }
    }
}
