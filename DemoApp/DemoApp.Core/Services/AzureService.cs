using DemoApp.Core.Configuration;
using DemoApp.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace DemoApp.Core.Services
{
    public class AzureService : IAzureService
    {
        private AzureSettings _settings;

        public AzureService(IOptions<AzureSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GetAValueFromSettings()
        {
            return _settings.AzureAccount;
        }
    }
}
