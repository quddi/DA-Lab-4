using System.Linq;
using System.Windows;

namespace DA_Lab_4
{
    public partial class MainWindow
    {
        private void OpenFileButtonClick(object sender, RoutedEventArgs e)
        {
            var loadedPairs = DataLoader.LoadValues();

            if (loadedPairs == null)
            {
                MessageBox.Show("Помилка при зчитуванні значень!");
                return;
            }

            DataContainer.Reset();

            DataContainer.Datas[typeof(RowData)] = loadedPairs
                .Select(pair => new RowData { X = pair.x, Y = pair.y})
                .ToGeneralDataList();
        }
    }
}
