namespace mobileapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Handle the login button click event
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // In a real app, you would validate the username and password
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please enter both username and password.", "OK");
            }
            else
            {
                // Simulate a successful login (or implement real authentication logic)
                await Navigation.PushAsync(new GamePage());
            }
        }
    }
}