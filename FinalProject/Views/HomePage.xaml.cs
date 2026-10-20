namespace FinalProject.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void OnAchievementsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Achievements", "Your achievements will appear here.", "OK");
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Settings", "Settings will be available here.", "OK");
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Profile", "Your profile settings will appear here.", "OK");
    }

    private async void OnMuscleActivityClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Muscle activity", "Your weekly muscle activity details will appear here.", "OK");
    }

    private async void OnChallengesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Weekly challenges", "Your weekly challenges will appear here.", "OK");
    }

    private async void OnFriendsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Friends", "Your friends page will appear here.", "OK");
    }

    private async void OnWorkoutClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Workouts", "Your workout page will appear here.", "OK");
    }

    private async void OnNutritionClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Nutrition", "Your nutrition page will appear here.", "OK");
    }

    private async void OnStatsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Statistics", "Your fitness statistics will appear here.", "OK");
    }
}