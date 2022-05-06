namespace Ingenium.Materiaalbeheer.ClientApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesome6Brands-Regular-400.otf", "FA-B");
                    fonts.AddFont("FontAwesome6Free-Regular-400", "FA-R");
                    fonts.AddFont("FontAwesome6Free-Solid-900", "FA-S");
                });

            return builder.Build();
        }
    }
}