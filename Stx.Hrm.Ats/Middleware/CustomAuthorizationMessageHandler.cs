using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Stx.Hrm.Ats.Middleware
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:6001/" }
                //scopes: new[] {
                //    //"https://Stxb2c.onmicrosoft.com/534163f7-e897-4260-88c0-4bbcf1271080/API.Access"
                //    //"API.Access"
                //    }
                );
        }
    }
}
