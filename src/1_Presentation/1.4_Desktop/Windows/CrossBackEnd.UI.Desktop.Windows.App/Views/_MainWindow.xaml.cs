
using CrossBackEnd.Shared.Infra.Abstractions;
using CrossBackEnd.UI.Desktop.Windows.App.Views.GeoLocation;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using CrossBackEnd.GeoLocation.Application.ViewModels;

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

            Teste();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountryManagerWindow frm = new CountryManagerWindow();

            frm.Show();
        }

        private async void Teste()
        {
            var request = App.Container.GetService<IRequestService>();
            
            var result = await request.GetAsync<IEnumerable<CountryViewModel>>("http://localhost:59496/api/v1.0/GeoLocation/Country");
        }
    }
}
