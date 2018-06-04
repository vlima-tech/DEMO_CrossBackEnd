
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossBackEnd.CrossPlatform.UI.Views._Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppNavigationPage : NavigationPage
	{
        public AppNavigationPage() : base()
        {
            InitializeComponent();
        }

        public AppNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}