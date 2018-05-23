
using System.Windows;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace CrossBackEnd.UI.Desktop.Windows
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Forms.Init();

            LoadApplication(new CrossPlatform.UI.App());
        }
    }
}