using Firebase.Auth;

namespace TransportGoApp
{

    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly FirebaseAuthClient _firebaseAuthClient;
        public MainPage(FirebaseAuthClient firebaseAuthClient)
        {
            InitializeComponent();
            _firebaseAuthClient = firebaseAuthClient;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(_firebaseAuthClient));
        }
    }

}
