namespace mobileapp;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();
        BindingContext = new StarRatingViewModel();
    }

}