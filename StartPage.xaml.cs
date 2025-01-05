namespace mobileapp;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private async void OnSessieStartenClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new GamePage());
    }

    private async void OnQuestionButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuestionPage());
    }
}