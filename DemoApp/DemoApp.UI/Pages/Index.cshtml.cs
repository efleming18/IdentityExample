using DemoApp.Core.Configuration;
using DemoApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DemoApp.UI.Pages
{
    public class IndexModel : PageModel
    {
        private AzureSettings _settings;
        private IAzureService _azureService;
        public string ValueFromSettingsDirectly { get; set; }
        public string ValueFromCallingAzureService { get; set; }

        public IndexModel(IOptions<AzureSettings> settings, IAzureService azureService)
        {
            _settings = settings.Value;
            _azureService = azureService;
        }

        public void OnGet()
        {
            ValueFromSettingsDirectly = _settings.AzureAccount;

            ValueFromCallingAzureService = _azureService.GetAValueFromSettings();
        }

        public async Task<IActionResult> OnPostGoToPrivacyPage()
        {
            return RedirectToPage("/Privacy");
        }
    }
}
