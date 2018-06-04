using System;
using System.Text;

namespace CrossBackEnd.Shared.Kernel.Core.Configuration
{
    public class Settings
    {
        private string apiEndPoint;
        private string apiVersion;

        public Settings()
        {
            //this.ApiEndPoint = "http://192.168.2.139:59496/api";
           // this.ApiEndPoint = "http://192.168.0.3:59496/api";
           // this.ApiVersion = "1.0";
        }

        public string ApiEndPoint
        {
            get { return this.apiEndPoint; }
            set { this.apiEndPoint = value; }
        }

        public string ApiVersion
        {
            get { return this.apiVersion; }
            set { this.apiVersion = value; }
        }
    }
}