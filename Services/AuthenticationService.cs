using Microsoft.Identity.Client;
using System.Diagnostics;

namespace Ingenium.Materiaalbeheer.ClientApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        //https://damienaicheh.github.io/azure/xamarin/xamarin.forms/2019/07/01/sign-in-with-microsoft-account-with-xamarin-en.html
        /// <summary>
        /// This object is used to know where to display the authentication activity (for Android) or page.
        /// </summary>
        public static object ParentWindow { get; set; }

        public async Task<string> GetToken()
        {

            AuthenticationResult authResult = null;
            var scopes = new[] { $"user.read", "api://apicode/user_impersonation" };
            var accounts = await AppSettings.PublicClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await AppSettings.PublicClientApp.AcquireTokenSilent(scopes, firstAccount).ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                try
                {
                    authResult = await AppSettings.PublicClientApp.AcquireTokenInteractive(scopes)
                    .WithAccount(accounts.FirstOrDefault())
                    .WithPrompt(Prompt.SelectAccount)
                    .WithParentActivityOrWindow(ParentWindow)
                    .WithAuthority(AppSettings._authority)
                    .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    Debug.WriteLine($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
            }
            if (authResult == null) return null;
            Debug.WriteLine(authResult.ExpiresOn.ToLocalTime());
            string token = authResult.AccessToken;
            return token;
        }

        //Afmelden
        public async Task SignOutAsync()
        {
            IEnumerable<IAccount> accounts = await AppSettings.PublicClientApp.GetAccountsAsync();

            try
            {
                while (accounts.Any())
                {
                    await AppSettings.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                    accounts = await AppSettings.PublicClientApp.GetAccountsAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
