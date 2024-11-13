using Microsoft.Maui.Controls;
using SwiftApp.Pages;


namespace SwiftApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}
