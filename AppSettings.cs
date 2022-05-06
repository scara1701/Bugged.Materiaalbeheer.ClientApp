using Ingenium.Materiaalbeheer.ClientApp.Services;
using Microsoft.Identity.Client;

namespace Ingenium.Materiaalbeheer.ClientApp
{
    public static class AppSettings
    {
        //fake client id for demo
        public static string _clientId = @"8740e589-0ab6-4364-a359-f1ef20ce0727";
        public static string _apiUrl = "https://materiaalapi.azurewebsites.net/api/";
        public static string _authority = "https://login.microsoftonline.com/8740e589-0ab6-4364-a359-f1ef20ce0727";
        public static IPublicClientApplication PublicClientApp { get; private set; }
        public static IAuthenticationService AuthenticationService { get; private set; }


        public static void Init()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(_clientId)
            //for ios
            //.WithIosKeychainSecurityGroup("com.microsoft.adalcache")
            .WithRedirectUri($"msal{_clientId}://auth")
            .WithAuthority(_authority)
            .Build();

            AuthenticationService = new AuthenticationService();
        }
    }
}
