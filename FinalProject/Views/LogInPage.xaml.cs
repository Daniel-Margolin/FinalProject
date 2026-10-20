using FinalProject.Services;
using System.Text.RegularExpressions;
namespace FinalProject.Views;

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
    }
    private async void OnWelcomePageClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }
    private async void OnSignInClicked(object sender, EventArgs e)
    {
        string email = Email.Text;
        string password = PassWord.Text;

        errEmail.Text = "";
        errPassword.Text = "";

        if (email == null || email == "")
        {
            errEmail.Text = "Email can't be Empty.";
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errEmail.Text = "Please enter a valid email address.";
            return;
        }

        if (password == null || password == "")
        {
            errPassword.Text = "Password can't be Empty.";
            return;
        }

        // Find the registered user.
        var user = DataRepository.FindUser(email, password);

        if (user == null)
        {
            errPassword.Text = "Incorrect email or password.";
            return;
        }

        // Goes to the HomePage
        await Navigation.PushAsync(new HomePage());

        // You can navigate to your home page here later.
    }
}