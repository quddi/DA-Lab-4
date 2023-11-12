using System.Linq;
using System.Windows;

namespace DA_Lab_4
{
    public partial class MainWindow
    {
        private void LoadDependentDatasetButtonClick(object sender, RoutedEventArgs e)
        {
            var loadedPairs = DataLoader.LoadValues(dependent: true);

            if (loadedPairs == null)
            {
                MessageBox.Show("Помилка при зчитуванні значень!");
                return;
            }

            DataContainer.Reset();

            //DataContainer.Datas[typeof(RowData)] = loadedPairs
            //    .Select(pair => new RowData { X = pair.x, Y = pair.y})
            //    .ToGeneralDataList();
        }

        private void LoadIndependentDatasetButtonClick(object sender, RoutedEventArgs e)
        {
            var loadedPairs = DataLoader.LoadValues(dependent: false);

            if (loadedPairs == null)
            {
                MessageBox.Show("Помилка при зчитуванні значень!");
                return;
            }

            DataContainer.Reset();

            //DataContainer.Datas[typeof(RowData)] = loadedPairs
            //    .Select(pair => new RowData { X = pair.x, Y = pair.y})
            //    .ToGeneralDataList();
        }
    }
}
