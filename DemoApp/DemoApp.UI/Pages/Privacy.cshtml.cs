using DemoApp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.UI.Pages
{
    [Authorize(Roles = AuthorizationConstants.Roles.ADMINISTRATORS)]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}