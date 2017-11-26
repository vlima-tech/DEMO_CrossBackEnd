
using SimpleInjector;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers;
using CrossBackEnd.CrossPlatform.Core.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Core.Controllers;

namespace CrossBackEnd.UI.Desktop.Windows.IoC
{
    public static class CrossPlatformBootStrapper
    {
        public static void AddCrossPlatform(this Container container)
        {
            container.Register<IBaseController, BaseController>();
            container.Register<ICountryManagerController, CountryManagerController>();
        }
    }
}