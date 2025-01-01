using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mobileapp;

// dit wordt nu niet gebruikt, 1-1-2025 20:04

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Word>().Wait();
    }

    public Task<int> AddWordAsync(Word word)
    {
        return _database.InsertAsync(word);
    }

    public Task<List<Word>> GetWordsAsync()
    {
        return _database.Table<Word>().ToListAsync();
    }
}

public class Word
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Text { get; set; }
}
