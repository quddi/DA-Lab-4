using DA_Lab_4;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

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

            Prepare();

            FillInfo();
        }

        private void Prepare()
        {
            MeansEqualityCheckbox.IsHitTestVisible = false;
            MeansEqualityCheckbox.Focusable = false;

            VariancesEqualityCheckbox.IsHitTestVisible = false;
            VariancesEqualityCheckbox.Focusable = false;

            VilcocsonCriteriaCheckbox.IsHitTestVisible = false;
            VilcocsonCriteriaCheckbox.Focusable = false;

            WelchCorrectionCheckbox.IsHitTestVisible = false;
            WelchCorrectionCheckbox.Focusable = false;
        }

        private void FillInfo()
        {
            if (_dataContainer.AreNormalDistributed)
            {
                //Set title
                EqualityTypeText.Text = "Вибірки нормально розподілені, отже до них було застосовано параметричні критерії";

                //Set VDV panel inactive
                VilcocsonPanelBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VilcocsonPanelBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VilcocsonCriteriaValuesText.Text = $"-";

                //Set mean and variance panel active
                MeanVariancePanelBackground.Fill = new SolidColorBrush(Constants.ActiveColor);

                //Set info
                var variancesFits = Math.Abs(_dataContainer.FTest) < _dataContainer.FisherQuantile;
                VariancesEqualityValuesText.Text = $"|{_dataContainer.FTest.ToFormattedString()}| < {_dataContainer.FisherQuantile.ToFormattedString()}";
                VariancesEqualityBackground.Fill = new SolidColorBrush(variancesFits ? Constants.OkColor : Constants.NotOkColor);
                VariancesEqualityCheckbox.IsChecked = variancesFits;

                var test = _dataContainer.PairedTTest;

                var meanFits = Math.Abs(test).IsLessOrEqual(_dataContainer.DifferencesDataContainer.StudentQuantile);
                MeansEqualityValuesText.Text = $"|{test.ToFormattedString()}| < {_dataContainer.DifferencesDataContainer.StudentQuantile.ToFormattedString()}";
                MeansEqualityBackground.Fill = new SolidColorBrush(meanFits ? Constants.OkColor : Constants.NotOkColor);
                MeansEqualityCheckbox.IsChecked = meanFits;
            }
            else
            {
                //Set title
                EqualityTypeText.Text = "Вибірки не розподілені нормально, отже до них було застосовано критерій знакових рангів Вілкоксона";

                //Set mean and variance panel inactive
                MeanVariancePanelBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VariancesEqualityValuesText.Text = $"-";
                VariancesEqualityBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                MeansEqualityValuesText.Text = $"-";
                MeansEqualityBackground.Fill = new SolidColorBrush(Constants.InactiveColor);

                //Set VDV panel active
                VilcocsonPanelBackground.Fill = new SolidColorBrush(Constants.ActiveColor);

                //TODO: Set info
                var vilcocsonCriteriaFits = _dataContainer.VilcocsonDifferences.Count == 0 || Math.Abs(_dataContainer.VilcocsonStatistics) < Constants.NormalDistributionQuantile;
                VilcocsonCriteriaValuesText.Text = _dataContainer.VilcocsonDifferences.Count == 0 
                    ? "Були відсутні різниці відмінні від нуля, отже вибірки однорідні!" 
                    : $"|{_dataContainer.VilcocsonStatistics}| < {Constants.NormalDistributionQuantile}";
                VilcocsonPanelBackground.Fill = new SolidColorBrush(vilcocsonCriteriaFits ? Constants.OkColor : Constants.NotOkColor);
                VilcocsonCriteriaCheckbox.IsChecked = vilcocsonCriteriaFits;
            }
        }

        private void ShowXDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_xDatasWindow != null) 
                return;

            _xDatasWindow = new DatasWindow(_dataContainer.XDataContainer, "Залежні вибірки: Перша вибірка");
            _xDatasWindow.Show();
            _xDatasWindow.Closed += (_, __) => _xDatasWindow = null;
        }

        private void ShowYDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_yDatasWindow != null)
                return;

            _yDatasWindow = new DatasWindow(_dataContainer.YDataContainer, "Залежні вибірки: Друга вибірка");
            _yDatasWindow.Show();
            _yDatasWindow.Closed += (_, __) => _yDatasWindow = null;
        }

        private void ShowDifferencesDatasWindowButtonClick(object _, RoutedEventArgs __)
        {
            if (_differencesDatasWindow != null) 
                return;

            _differencesDatasWindow = new DatasWindow(_dataContainer.DifferencesDataContainer, "Залежні вибірки: Вибірка різниць");
            _differencesDatasWindow.Show();
            _differencesDatasWindow.Closed += (_, __) => _differencesDatasWindow = null;
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
