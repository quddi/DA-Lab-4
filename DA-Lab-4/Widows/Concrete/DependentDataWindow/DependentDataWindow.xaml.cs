using System;
using System.Windows;

namespace DA_Lab_4
{
    public partial class DependentDataWindow : Window
    {
        public DependentDataWindow()
        {
            InitializeComponent();
        }

        private void CheckMeansEqualityButtonClick(object sender, RoutedEventArgs e)
        {
            var tTest = DependentDataContainer.DifferencesPairedTTest;
            var studentQuantile = DependentDataContainer.DifferencesStudentQuantile;

            var tTestAbs = Math.Abs(tTest);

            if (tTestAbs.IsLessOrEqual(studentQuantile))
            {
                MessageBox.Show($"Немає підстав відхиляти гіпотезу про рівність середніх значень сукупностей.\n|{tTest}| <= {studentQuantile}");
            }
            else
            {
                MessageBox.Show($"Середні значення істотно відрізняються.\n|{tTest}| > {studentQuantile}");
            }
        }

        private void CheckVariancesEqualityButton_Click(object sender, RoutedEventArgs e)
        {
            var fTest = DependentDataContainer.DifferencesFTest;
            var fisherQuantile = DependentDataContainer.DifferencesStudentQuantile;

            var fTestAbs = Math.Abs(fTest);

            if (fTestAbs.IsLessOrEqual(fisherQuantile))
            {
                MessageBox.Show($"Дисперсії генеральних сукупностей, з яких вилучено вибірки, збігаються.\n|{fTest}| <= {fisherQuantile}");
            }
            else
            {
                MessageBox.Show($"Дисперсії відмінні.\n|{fTest}| > {fisherQuantile}");
            }
        }
    }
}
