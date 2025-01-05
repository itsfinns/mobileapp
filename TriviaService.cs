using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class TriviaService
{
    private readonly HttpClient _httpClient;

    public TriviaService()
    {
        _httpClient = new HttpClient();
    }

    // Methode om trivia vragen op te halen
    public async Task<List<Vraag>> HaalVragenOpAsync(int aantal = 10)
    {
        string url = $"https://opentdb.com/api.php?amount={aantal}";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var triviaResponse = JsonSerializer.Deserialize<TriviaAntwoord>(json);
            return triviaResponse?.Resultaten ?? new List<Vraag>();
        }

        throw new Exception("Kon de trivia vragen niet ophalen.");
    }
}

// Model voor de API-respons
public class TriviaAntwoord
{
    public int ResponseCode { get; set; }
    public List<Vraag> Resultaten { get; set; }
}

// Model voor een trivia vraag
public class Vraag
{
    public string Categorie { get; set; }
    public string Type { get; set; }
    public string Moeilijkheid { get; set; }
    public string VraagTekst { get; set; }
    public string CorrectAntwoord { get; set; }
    public List<string> FouteAntwoorden { get; set; }
}
