using CommunityToolkit.Mvvm.Input;
using Ingenium.Materiaalbeheer.ClientApp.Services;
using System.Diagnostics;

namespace Ingenium.Materiaalbeheer.ClientApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public static async Task<LoginViewModel> Create()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            if (!RESTService.signedIn)
                await RESTService.Initialize(AppSettings._apiUrl);
            return loginViewModel;
        }


        [ICommand]
        public async void SignIn()
        {
            await RESTService.Initialize(AppSettings._apiUrl);
            if (RESTService.signedIn) SignedIn();
        }

        [ICommand]
        public async void SignedIn()
        {
            //go to mainpage
            Debug.WriteLine("We are signed in!");
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}
