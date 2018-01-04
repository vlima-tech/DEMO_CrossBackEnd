using System;
using System.Text;

namespace CrossBackEnd.Shared.Kernel.Core.Configuration
{
    public class Settings
    {
        private const string DefaultApiEndPoint = "http://192.168.0.34:59496/api";
        private const string DefaultApiVersion = "1.0";

        public static string ApiEndPoint
        {
            get { return DefaultApiEndPoint; }
            set {  }
        }

        public static string ApiVersion
        {
            get { return DefaultApiVersion; }
        }
    }
}