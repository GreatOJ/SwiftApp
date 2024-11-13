using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using SwiftApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftApp.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string? _username;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;
        public SignUpPageViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [RelayCommand]
        private async Task Register()
        {
            await _authClient.CreateUserWithEmailAndPasswordAsync(Email, Password);
            await Shell.Current.GoToAsync(nameof(HomePage));
        }

        [RelayCommand]
        private async Task NavigateLogin()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
