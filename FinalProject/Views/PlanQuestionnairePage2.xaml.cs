namespace FinalProject.Views;

public partial class PlanQuestionnairePage2 : ContentPage
{
    private readonly string _goal;
    private readonly int _age;
    private readonly double _height;
    private readonly double _weight;

    public PlanQuestionnairePage2(
        string goal,
        int age,
        double height,
        double weight)
    {
        InitializeComponent();

        _goal = goal;
        _age = age;
        _height = height;
        _weight = weight;
    }

    private void OnCaloriesUnknownChanged(
        object sender,
        CheckedChangedEventArgs e)
    {
        CaloriesEntry.IsEnabled = !e.Value;

        if (e.Value)
            CaloriesEntry.Text = string.Empty;
    }

    private async void OnContinueClicked(
        object sender,
        EventArgs e)
    {
        string currentDays = GetSelected(
            Current0, Current12, Current34,
            Current56, CurrentEvery);

        string availableDays = GetSelected(
            Available12, Available3, Available4,
            Available5, Available67);

        string activity = GetSelected(
            ActivitySitting, ActivityLight,
            ActivityModerate, ActivityVery);

        string location = GetSelected(
            LocationHome, LocationGym, LocationBoth);

        if (string.IsNullOrEmpty(currentDays) ||
            string.IsNullOrEmpty(availableDays) ||
            string.IsNullOrEmpty(activity) ||
            string.IsNullOrEmpty(location))
        {
            await DisplayAlert(
                "Missing information",
                "Please answer all training questions.",
                "OK");
            return;
        }

        int? calories = null;

        if (!CaloriesUnknownCheckBox.IsChecked)
        {
            if (!int.TryParse(
                    CaloriesEntry.Text,
                    out int parsedCalories) ||
                parsedCalories < 500 ||
                parsedCalories > 10000)
            {
                await DisplayAlert(
                    "Invalid calories",
                    "Enter your daily calories or select I don't know.",
                    "OK");
                return;
            }

            calories = parsedCalories;
        }

        // The questionnaire is complete.
        // These answers can now be passed to registration.

        await Navigation.PushAsync(new RegisterPage());
    }

    private static string GetSelected(
        params RadioButton[] buttons)
    {
        foreach (RadioButton button in buttons)
        {
            if (button.IsChecked)
                return button.Content?.ToString() ?? "";
        }

        return "";
    }

    private async void OnBackClicked(
        object sender,
        EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
            await Navigation.PopAsync();
    }
}
