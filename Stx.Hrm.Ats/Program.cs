    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.AspNetCore.Http;
    using Radzen;
    using Stx.Hrm.Ats;
    using Stx.Hrm.Ats.Core;
using Stx.Hrm.Ats.Middleware;
using Stx.HRM.Services.Common;
    using Stx.HRM.Services.CRM;
    using Stx.HRM.Services.HRM;
    using Stx.Shared.Interfaces;
    using Stx.Shared.Interfaces.Common;
    using Stx.Shared.Interfaces.CRM;
    using Stx.Shared.Interfaces.HRM;
    using Stx.Shared.Services;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider, AtsAuthenticationStateProvider>();

#region System Services
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
#endregion

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://Stxb2c.onmicrosoft.com/534163f7-e897-4260-88c0-4bbcf1271080/API.Access");
    options.ProviderOptions.LoginMode = "redirect";
});

//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("oidc", options.ProviderOptions);
//    //options.ProviderOptions.Authority = "https://localhost:5001/";
//    //options.ProviderOptions.ClientId = "hrm_ats";
//    //options.ProviderOptions.ResponseType = "code"; //"code id_token";
//    //options.ProviderOptions.PostLogoutRedirectUri = "/";
//    //options.ProviderOptions.PostLogoutRedirectUri = "";

//    //options.ProviderOptions.DefaultScopes.Add("usr");
//    ////options.ProviderOptions.DefaultScopes.Add("profileimg");
//    //options.ProviderOptions.DefaultScopes.Add("offline_access");
//    ////options.ProviderOptions.DefaultScopes.Add("hrm.ats");
//});

#region Service HTTP Client
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
builder.Services.AddTransient<HttpRequestHandler>();
string api = builder.Configuration["Services:Api"];

    builder.Services.AddHttpClient("JPAPI", c =>
    {
        c.BaseAddress = new Uri(api);
    })
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>()
    .AddHttpMessageHandler<HttpRequestHandler>(); //for testing (eg: sent custom access token)

    // Supply HttpClient instances that include access tokens when making requests to the server project
    builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("JPAPI"));
    #endregion

    #region Domain Services

    //Uri apiUrl = new Uri(Configuration.GetConnectionString("AP"));
    //builder.Services.AddHttpClient<IApiHelperDataService, ApiHelperDataService>(client => { client.BaseAddress = apiUrl; });
    builder.Services.AddScoped<IApiHelperDataService, ApiHelperDataService>();
    builder.Services.AddScoped<IEmailClientDataService, EmailClientDataService>();
    builder.Services.AddScoped<IHrmGeneralDataService, HrmGeneralDataService>();

    //CRM
    builder.Services.AddScoped<ICorporateDataService, CorporateDataService>();
    builder.Services.AddScoped<ICorporateSettingsDataService, CorporateSettingsDataService>();

    builder.Services.AddScoped<ICandidatePublicDataService, CandidatePublicDataService>();
    builder.Services.AddScoped<ICandidateEvaluateDataService, CandidateEvaluateDataService>();
    builder.Services.AddScoped<IJobOrderDataService, JobOrderDataService>();
    builder.Services.AddScoped<IJobCandidateDataService, JobCandidateDataService>();
    builder.Services.AddScoped<IJobScorecardDataService, JobScorecardDataService>();

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
//builder.Services.AddScoped<TooltipService>();
//builder.Services.AddScoped<ContextMenuService>();
#endregion

//builder.Services.AddApiAuthorization();

builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();



