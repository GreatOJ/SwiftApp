using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftApp.Pages;

namespace SwiftApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;
        public MainPageViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }
        public string? Username => _authClient.User?.Info?.DisplayName;

        [RelayCommand]
        private async Task Login()
        {
            try
            {
                await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);

                OnPropertyChanged(nameof(Username));
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            catch (Exception ex)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

        }

        [RelayCommand]
        private async Task NavigateSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }


    }
}
