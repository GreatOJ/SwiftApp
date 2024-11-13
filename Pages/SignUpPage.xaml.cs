using SwiftApp.ViewModels;
namespace SwiftApp.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}