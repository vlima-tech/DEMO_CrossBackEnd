using CrossBackEnd.Shared.Kernel.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossBackEnd.GeoLocation.Infra.Client.Data.Helpers
{
    public static class RouteHelper
    {
        public static Uri GenerateUrl<TModel>(string apiEndPoint, string apiVersion)
        {
            string className, _namespace;
            UriBuilder builder;
            
            builder = new UriBuilder(apiEndPoint);

            className = typeof(TModel).Name;
            _namespace = GenerateRouteNamespace<TModel>();

            builder.AppendToPath("v" + apiVersion);
            builder.AppendToPath(_namespace);
            builder.AppendToPath(className);

            return builder.Uri;
        }

        private static string GenerateRouteNamespace<TModel>()
        {
            string _namespace = "";

            _namespace = typeof(TModel).Namespace
                .Substring(0, typeof(TModel).Namespace.ToLower().IndexOf("domain") - 1);

            _namespace = _namespace.Substring(_namespace.LastIndexOf('.') + 1);

            return _namespace;
        }
    }
}
