using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Core.Configuration
{
    public class AzureSettings
    {
        public string AzureAccount { get; set; }
        public string AzureAccountBaseUrl { get; set; }
        public string MainAppContainer { get; set; }
        public string PublicContainer { get; set; }
        public string PrivateContainer { get; set; }
        public string MasterEmailTemplate { get; set; }
        public string AzurePrimaryConnectionString { get; set; }
        public string AzurePrimaryAccountKey { get; set; }
    }
}
