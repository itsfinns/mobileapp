using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace mobileapp;
public class StarRatingViewModel : INotifyPropertyChanged
{
    private int _selectedStars;

    public event PropertyChangedEventHandler PropertyChanged;

    public int SelectedStars
    {
        get => _selectedStars;
        set
        {
            _selectedStars = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(StarImages));
        }
    }

    public ICommand StarTappedCommand => new Command<int>(OnStarTapped);

    private void OnStarTapped(int star)
    {
        SelectedStars = star;
    }

    public string[] StarImages => new string[]
    {
        SelectedStars >= 1 ? "star_filled.png" : "star_outline.png",
        SelectedStars >= 2 ? "star_filled.png" : "star_outline.png",
        SelectedStars >= 3 ? "star_filled.png" : "star_outline.png",
        SelectedStars >= 4 ? "star_filled.png" : "star_outline.png",
        SelectedStars >= 5 ? "star_filled.png" : "star_outline.png",
    };

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
