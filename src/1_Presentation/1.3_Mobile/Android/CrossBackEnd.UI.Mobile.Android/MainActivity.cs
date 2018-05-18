using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;

using CrossBackEnd.CrossPlatform.UI;

namespace CrossBackEnd.UI.Mobile.Droid
{
    [Activity(Label = "CrossBackEnd.UI.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            LoadApplication(new App());
        }
    }
}

