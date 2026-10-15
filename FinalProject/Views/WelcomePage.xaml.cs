using FinalProject.Views;

namespace FinalProject.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}
    private async void OnSignUpClicked(
        object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(RegisterPage));
    }

    private async void OnLoginClicked(
        object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(LogInPage));
    }
}