using System.Globalization;

namespace FinalProject.Views;

public partial class PlanQuestionnairePage : ContentPage
{
    public PlanQuestionnairePage()
    {
        InitializeComponent();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        string goal = "";

        if (LoseFatRadio.IsChecked)
            goal = "Lose body fat";
        else if (BuildMuscleRadio.IsChecked)
            goal = "Build muscle";
        else if (RecompRadio.IsChecked)
            goal = "Lose fat and build muscle";
        else if (FitnessRadio.IsChecked)
            goal = "Improve fitness";

        if (string.IsNullOrEmpty(goal))
        {
            await DisplayAlert(
                "Missing information",
                "Please select your main goal.",
                "OK");
            return;
        }

        if (!int.TryParse(AgeEntry.Text, out int age) ||
            age < 14 || age > 100)
        {
            await DisplayAlert(
                "Invalid age",
                "Please enter a valid age.",
                "OK");
            return;
        }

        if (!double.TryParse(
                HeightEntry.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out double height) ||
            height < 50 || height > 250)
        {
            await DisplayAlert(
                "Invalid height",
                "Please enter a height between 50 and 250 cm.",
                "OK");
            return;
        }

        if (!double.TryParse(
                WeightEntry.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out double weight) ||
            weight < 20 || weight > 350)
        {
            await DisplayAlert(
                "Invalid weight",
                "Please enter a weight between 20 and 350 kg.",
                "OK");
            return;
        }
        await Navigation.PushAsync(
        new PlanQuestionnairePage2(
        goal,
        age,
        height,
        weight));
    }
}