using System.Windows;

namespace DA_Lab_4
{
    public partial class MainWindow
    {
        private void LoadDependentDatasetButtonClick(object sender, RoutedEventArgs e)
        {
            var datas = DataLoader.LoadValues(dependent: true);

            if (datas == null)
            {
                MessageBox.Show("Помилка при зчитуванні значень!");
                return;
            }

            DependentDataContainer.SetDatas(datas.Value);

            WindowsResponsible.ShowWindow<DependentDataWindow>();
        }

        private void LoadIndependentDatasetButtonClick(object sender, RoutedEventArgs e)
        {
            var datas = DataLoader.LoadValues(dependent: false);

            if (datas == null)
            {
                MessageBox.Show("Помилка при зчитуванні значень!");
                return;
            }

            IndependentDataContainer.SetDatas(datas.Value);
        }
    }
}
