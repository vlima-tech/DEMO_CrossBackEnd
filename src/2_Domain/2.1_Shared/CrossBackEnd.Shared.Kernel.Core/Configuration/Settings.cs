using System;
using System.Text;

namespace CrossBackEnd.Shared.Kernel.Core.Configuration
{
    public class Settings
    {
        public Settings()
        {
            this.ApiEndPoint = "http://192.168.2.139:59496/api";
            //this.ApiEndPoint = "http://192.168.0.2:59496/api";
            this.ApiVersion = "1.0";
        }

        public string ApiEndPoint { get; private set; }

        public string ApiVersion { get; private set; }
    }
}