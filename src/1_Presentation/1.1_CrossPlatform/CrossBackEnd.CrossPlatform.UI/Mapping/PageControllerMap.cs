
using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

using CrossBackEnd.CrossPlatform.Abstractions.Controllers.GeoLocation;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers.Home;
using CrossBackEnd.CrossPlatform.UI.Views._Home;
using CrossBackEnd.CrossPlatform.UI.Views.GeoLocation;
using CrossBackEnd.CrossPlatform.Abstractions.Controllers;

namespace CrossBackEnd.CrossPlatform.UI.Mapping
{
    public class PageControllerMap : Dictionary<Type, Type>
    {
        public static Dictionary<Type, Type> Mapping { get { return GeneratePageControllerMappings(); } }

        public PageControllerMap()
        {
            CreatePageViewModelMappings();
        }
        
        private void CreatePageViewModelMappings()
        {
            foreach(var item in GeneratePageControllerMappings())
                base.Add(item.Key, item.Value);
        }

        private static Dictionary<Type, Type> GeneratePageControllerMappings()
        {
            var dictionary = new Dictionary<Type, Type>();

            // Add here Commom Views to every Devices

            dictionary.Add(typeof(IHomeController), typeof(HomePage));

            dictionary.Add(typeof(ICountryController), typeof(CountryPage));
            dictionary.Add(typeof(ICountryDetailsController), typeof(CountryDetailsPage));

            // Add here custom Specifics Views to Specific Device

            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                    break;

                case TargetIdiom.Phone:
                    break;

                case TargetIdiom.Tablet:
                    break;

                case TargetIdiom.TV:
                    break;
            }

            return dictionary;
        }

        public Type GetPageTypeForController(Type controllerType)
        {
            if (!base.ContainsKey(controllerType))
            {
                throw new KeyNotFoundException($"No map for ${controllerType} was found on navigation mappings");
            }

            return base[controllerType];
        }

        public Type GetPageTypeForController<TController>() where TController : IBaseController
        {
            if (!base.ContainsKey(typeof(TController)))
            {
                throw new KeyNotFoundException($"No map for ${typeof(TController)} was found on navigation mappings");
            }

            return base[typeof(TController)];
        }
    }
}