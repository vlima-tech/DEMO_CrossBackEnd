
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossBackEnd.CrossPlatform.UI.Bootstrap.Windows
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WindowsRootPage : MasterDetailPage
	{
        public WindowsRootPage()
        {
            InitializeComponent();
        }
	}
}