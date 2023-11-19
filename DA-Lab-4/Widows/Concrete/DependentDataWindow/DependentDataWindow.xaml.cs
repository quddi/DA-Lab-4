using DA_Lab_4.Widows.Concrete.DatasWindow;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DA_Lab_4
{
    public partial class DependentDataWindow : Window
    {
        private DependentDataContainer _dataContainer;

        private DatasWindow? _xDatasWindow;
        private DatasWindow? _yDatasWindow;
        private DatasWindow? _differencesDatasWindow;

        public DependentDataWindow((List<double> X, List<double> Y) datas)
        {
            InitializeComponent();

            _dataContainer = new DependentDataContainer(datas);
        }

        private void CheckMeansEqualityButtonClick(object sender, RoutedEventArgs e)
        {
            var tTest = _dataContainer.PairedTTest;
            var studentQuantile = _dataContainer.DifferencesDataContainer.StudentQuantile;

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
            var fTest = _dataContainer.FTest;
            var fisherQuantile = _dataContainer.DifferencesDataContainer.StudentQuantile;

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

        private void ShowXDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_xDatasWindow != null) 
                return;

            _xDatasWindow = new DatasWindow(_dataContainer.XDataContainer, "Залежні вибірки: Перша вибірка");
            _xDatasWindow.Show();
        }

        private void ShowYDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_yDatasWindow != null)
                return;

            _yDatasWindow = new DatasWindow(_dataContainer.YDataContainer, "Залежні вибірки: Друга вибірка");
            _yDatasWindow.Show();
        }

        private void ShowDifferencesDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_differencesDatasWindow != null) 
                return;

            _differencesDatasWindow = new DatasWindow(_dataContainer.DifferencesDataContainer, "Залежні вибірки: Вибірка різниць");
            _differencesDatasWindow.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            _xDatasWindow?.Close();
            _yDatasWindow?.Close();
            _differencesDatasWindow?.Close();

            base.OnClosed(e);
        }
    }
}
