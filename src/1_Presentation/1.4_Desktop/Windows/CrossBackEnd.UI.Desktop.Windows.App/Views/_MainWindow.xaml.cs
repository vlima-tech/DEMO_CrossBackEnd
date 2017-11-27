
using CrossBackEnd.UI.Desktop.Windows.App.Views.GeoLocation;
using System.Windows;

namespace CrossBackEnd.UI.Desktop.Windows.App.Views
{
    /// <summary>
    /// Lógica interna para _MainWindow.xaml
    /// </summary>
    public partial class _MainWindow : Window
    {
        public _MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountryManagerWindow frm = new CountryManagerWindow();

            frm.Show();
        }
    }
}
