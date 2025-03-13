using Firebase.Auth;

namespace TransportGoApp;

public partial class RegisterPage : ContentPage
{
    private readonly FirebaseAuthClient _firebaseAuthClient;

    public RegisterPage(FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        _firebaseAuthClient = firebaseAuthClient;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        try
        {
            // Creare utilizator nou
            var userCredential = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password);

            if (userCredential != null)
            {
                await DisplayAlert("Succes", "Înregistrare reușită!", "OK");
                await Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            // Gestionare erori
            await DisplayAlert("Eroare", ex.Message, "OK");
        }
    }
}
