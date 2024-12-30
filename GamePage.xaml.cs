namespace mobileapp;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
	}

	private async void OnGetWordClicked(object sender, EventArgs e)
	{
        base.OnAppearing();

        var dbService = new DatabaseService();
        var words = await dbService.GetWordsAsync();

        if (words.Count == 0) // Voeg woorden toe als de database leeg is
        {
            await dbService.AddWordAsync(new Word { Text = "Appel" });
            await dbService.AddWordAsync(new Word { Text = "Banaan" });
            await dbService.AddWordAsync(new Word { Text = "Kers" });
        }
    }
    private async void OnRandomWordButtonClicked(object sender, EventArgs e)
    {
        var dbService = new DatabaseService();
        var words = await dbService.GetWordsAsync();

        if (words.Count > 0)
        {
            var random = new Random();
            var randomWord = words[random.Next(words.Count)];
            GetWordButton.Text = randomWord.Text;
        }
        else
        {
            GetWordButton.Text = "Geen woorden beschikbaar!";
        }
    }

}