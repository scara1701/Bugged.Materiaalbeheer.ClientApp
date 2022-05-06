namespace Ingenium.Materiaalbeheer.ClientApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(GebruikersPage), typeof(GebruikersPage));
            Routing.RegisterRoute(nameof(LeverancierPage), typeof(LeverancierPage));
            Routing.RegisterRoute(nameof(MateriaalPage), typeof(MateriaalPage));
            Routing.RegisterRoute(nameof(TypenPage), typeof(TypenPage));
            Routing.RegisterRoute(nameof(AfdelingenPage), typeof(AfdelingenPage));
        }
    }
}