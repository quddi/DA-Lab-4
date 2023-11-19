﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DA_Lab_4.Widows.Concrete.DatasWindow
{
    public partial class DatasWindow : Window
    {
        private readonly DataContainer _dataContainer;

        public DatasWindow(DataContainer dataContainer, string windowName)
        {
            InitializeComponent();

            Title = windowName;

            _dataContainer = dataContainer;

            Prepare();

            FillInfo();
        }

        private void Prepare()
        {
            var column = (DataGridTextColumn)ValuesDataGrid.Columns[0];

            column.Binding = new Binding(nameof(DataGridItem.FormattedValue));

            ValuesDataGrid.IsReadOnly = true;

            MeanTextBox.IsReadOnly = true;
            MeanIntervalTextBox.IsReadOnly = true;

            MedianTextBox.IsReadOnly = true;
            MedianIntervalTextBox.IsReadOnly = true;

            StandardDeviationTextBox.IsReadOnly = true;
            StandardDeviationIntervalTextBox.IsReadOnly = true;

            SkewnessCoefficientTextBox.IsReadOnly = true;
            SkewnessCoefficientIntervalTextBox.IsReadOnly = true;

            KurtosisCoefficientTextBox.IsReadOnly = true;
            KurtosisCoefficientIntervalTextBox.IsReadOnly = true;
        }

        private void FillInfo()
        {
            var items = _dataContainer.Datas
                .Select(data => new DataGridItem() { Value = data })
                .OrderBy(item => item.Value)
                .ToList();

            items.ForEach(item => ValuesDataGrid.Items.Add(item));

            MeanTextBox.Text = _dataContainer.Mean.ToFormattedString();
            MeanIntervalTextBox.Text = _dataContainer.MeanTrustInterval.ToFormattedString();

            MedianTextBox.Text = _dataContainer.Median.ToFormattedString();
            MedianIntervalTextBox.Text = _dataContainer.MedianTrustInterval.ToFormattedString();

            StandardDeviationTextBox.Text = _dataContainer.StandardDeviation.ToFormattedString();
            StandardDeviationIntervalTextBox.Text = _dataContainer.StandardDeviationTrustInterval.ToFormattedString();

            SkewnessCoefficientTextBox.Text = _dataContainer.SecondSkewnessCoefficient.ToFormattedString();
            SkewnessCoefficientIntervalTextBox.Text = _dataContainer.SecondSkewnessCoefficientTrustInterval.ToFormattedString();

            KurtosisCoefficientTextBox.Text = _dataContainer.SecondKurtosisCoefficient.ToFormattedString();
            KurtosisCoefficientIntervalTextBox.Text = _dataContainer.SecondKurtosisCoefficientTrustInterval.ToFormattedString();
        }

        private class DataGridItem
        {
            public double Value { get; set; }

            public string FormattedValue => Value.ToFormattedString();
        }
    }
}