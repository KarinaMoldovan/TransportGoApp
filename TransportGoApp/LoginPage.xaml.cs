using Firebase.Auth;

namespace TransportGoApp;

public partial class LoginPage : ContentPage
{
    private readonly FirebaseAuthClient _firebaseAuthClient;

    public LoginPage(FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        _firebaseAuthClient = firebaseAuthClient;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
      
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        try
        {
            // Autentificarea utilizatorului
            var userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
        

        // Navigare către Dashboard dacă autentificarea reușește
           if (userCredential != null)
              {
               await DisplayAlert("Succes", "Autentificare reușită!", "OK");
              //await Navigation.PushAsync(new DashboardPage());
              }
         }
        catch (Exception ex)
        {
            // Gestionare erori
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Navigare către pagina de înregistrare
        await Navigation.PushAsync(new RegisterPage(_firebaseAuthClient));
    }
}
