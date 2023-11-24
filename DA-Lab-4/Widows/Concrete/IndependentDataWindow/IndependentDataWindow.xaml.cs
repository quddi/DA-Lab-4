using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace DA_Lab_4
{
    public partial class IndependentDataWindow : Window
    {
        private IndependentDataContainer _dataContainer;

        private DatasWindow? _xDatasWindow;
        private DatasWindow? _yDatasWindow;

        public IndependentDataWindow((List<double> X, List<double> Y) datas)
        {
            InitializeComponent();

            _dataContainer = new IndependentDataContainer(datas);

            Prepare();

            FillInfo();
        }

        private void Prepare()
        {
            MeansEqualityCheckbox.IsHitTestVisible = false;
            MeansEqualityCheckbox.Focusable = false;

            VariancesEqualityCheckbox.IsHitTestVisible = false;
            VariancesEqualityCheckbox.Focusable = false;

            VDVCriteriaCheckbox.IsHitTestVisible = false;
            VDVCriteriaCheckbox.Focusable = false;

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
                VDVCriteriaBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VDVPanelBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VDVCriteriaValuesText.Text = $"-";

                //Set mean and variance panel active
                MeanVariancePanelBackground.Fill = new SolidColorBrush(Constants.ActiveColor);

                //Set info
                var variancesFits = Math.Abs(_dataContainer.FTest) < _dataContainer.FisherQuantile;
                VariancesEqualityValuesText.Text = $"|{_dataContainer.FTest.ToFormattedString()}| < {_dataContainer.FisherQuantile.ToFormattedString()}";
                VariancesEqualityBackground.Fill = new SolidColorBrush(variancesFits ? Constants.OkColor : Constants.NotOkColor);
                VariancesEqualityCheckbox.IsChecked = variancesFits;

                var withWelchCorrection = !variancesFits;

                var test = withWelchCorrection ? _dataContainer.WelchTTest : _dataContainer.TwoSampleTTest;

                var meanFits = Math.Abs(test) < _dataContainer.StudentQuantile;
                MeansEqualityValuesText.Text = $"|{test.ToFormattedString()}| < {_dataContainer.StudentQuantile.ToFormattedString()}";
                MeansEqualityBackground.Fill = new SolidColorBrush(meanFits ? Constants.OkColor : Constants.NotOkColor);
                MeansEqualityCheckbox.IsChecked = meanFits;
            }
            else
            {
                //Set title
                EqualityTypeText.Text = "Вибірки не розподілені нормально, отже до них було застосовано критерій Ван дер Вардена";

                //Set mean and variance panel inactive
                MeanVariancePanelBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                VariancesEqualityValuesText.Text = $"-";
                VariancesEqualityBackground.Fill = new SolidColorBrush(Constants.InactiveColor);
                MeansEqualityValuesText.Text = $"-";
                MeansEqualityBackground.Fill = new SolidColorBrush(Constants.InactiveColor);

                //Set VDV panel active
                VDVCriteriaBackground.Fill = new SolidColorBrush(Constants.ActiveColor);

                //Set info
                var vdvFits = Math.Abs(_dataContainer.XUValue) < _dataContainer.XDataContainer.NormalDistributionQuantile;
                VDVCriteriaValuesText.Text = $"|{_dataContainer.XUValue}| < {_dataContainer.XDataContainer.NormalDistributionQuantile}";
                VDVCriteriaBackground.Fill = new SolidColorBrush(vdvFits ? Constants.OkColor : Constants.NotOkColor);
                VDVCriteriaCheckbox.IsChecked = vdvFits;
            }
        }

        private void ShowXDatasWindowButtonClick(object sender, RoutedEventArgs e)
        {
            if (_xDatasWindow != null)
                return;

            _xDatasWindow = new DatasWindow(_dataContainer.XDataContainer, "Залежні вибірки: Перша вибірка");
            _xDatasWindow.Show();
            _xDatasWindow.Closed += (_, __) => _xDatasWindow = null;
        }

        private void ShowYDatasWindowButtonClick(object sender, RoutedEventArgs e)
        {
            if (_yDatasWindow != null)
                return;

            _yDatasWindow = new DatasWindow(_dataContainer.YDataContainer, "Залежні вибірки: Друга вибірка");
            _yDatasWindow.Show();
            _yDatasWindow.Closed += (_, __) => _yDatasWindow = null;
        }

        protected override void OnClosed(EventArgs e)
        {
            _xDatasWindow?.Close();
            _yDatasWindow?.Close();

            base.OnClosed(e);
        }
    }
}
