using Microsoft.Extensions.Logging;
using Firebase.Auth.Providers;
using Firebase.Auth;
using SwiftApp.ViewModels;
using SwiftApp.Pages;


namespace SwiftApp
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                AuthDomain = "swift-bcfc0.firebaseapp.com",
                ApiKey = "AIzaSyAaW0oHo8JrQ7G_uaczRtYOP6jsByvV-0c",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<SignUpPageViewModel>();
            builder.Services.AddSingleton<MainPageViewModel>();


            return builder.Build();
        }
    }
}
