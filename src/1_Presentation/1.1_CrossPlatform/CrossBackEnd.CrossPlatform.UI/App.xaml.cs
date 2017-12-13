
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CrossBackEnd.CrossPlatform.UI.Bootstrap.Android;

namespace CrossBackEnd.CrossPlatform.UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    MainPage = new AndroidRootPage();
                    break;

                case Device.iOS:
                    break;
            }
        }
	}
}