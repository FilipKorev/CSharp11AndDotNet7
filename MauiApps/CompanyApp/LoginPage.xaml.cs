namespace CompanyApp;

public partial class LoginPage : ContentPage
{
	public InitDatabase initDatabase { get; set; } = new InitDatabase ();
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		User user = await initDatabase.GetItemAsync(UName.Text , Password.Text);
		if (!string.IsNullOrEmpty(user.Name)) 
		{
            await Navigation.PushAsync(new MainPage());
			UName.Text = "";
			Password.Text = "";
			
		}
		else
		{
			await DisplayAlert("", "Invalid logIn", "Ok");
		}
    }
}