namespace Ingenium.Materiaalbeheer.ClientApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppSettings.Init();
            MainPage = new AppShell();
        }
    }
}