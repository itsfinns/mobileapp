using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

public class TriviaViewModel : BaseViewModel
{
    private readonly TriviaService _triviaService;

    public ObservableCollection<Vraag> Vragen { get; } = new();
    public bool HeeftVragen => Vragen.Count > 0;

    public ICommand HaalVragenCommand { get; }

    public TriviaViewModel()
    {
        _triviaService = new TriviaService();
        HaalVragenCommand = new Command(async () => await HaalVragenAsync());
    }

    private async Task HaalVragenAsync()
    {
        var vragen = await _triviaService.HaalVragenOpAsync();
        Vragen.Clear();
        foreach (var vraag in vragen)
        {
            Vragen.Add(vraag);
        }
        OnPropertyChanged(nameof(HeeftVragen));
    }
}
