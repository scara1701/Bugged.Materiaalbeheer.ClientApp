using Ingenium.Materiaalbeheer.ClientApp.Services;
using Ingenium.Materiaalbeheer.ClientApp.ViewModels;

namespace Ingenium.Materiaalbeheer.ClientApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        BindingContext = await LoginViewModel.Create();
        if (RESTService.signedIn)
        {
            ((LoginViewModel)BindingContext).SignedInCommand.Execute(this);
        }
    }
}