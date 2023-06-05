namespace CompanyApp;

public partial class RegistrationPage : ContentPage
{
	public InitDatabase initDatabase { get; set; } 
	public RegistrationPage()
	{
		InitializeComponent();
		initDatabase = new InitDatabase();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		User user = new User();
		user.Name = Name.Text;
		Name.Text = "";
		user.Surname = Surename.Text;
		Surename.Text = "";
		user.Phone = Phone.Text;
		Phone.Text = "";
		user.UserName = Username.Text;
		Username.Text = "";
		user.WorkPosition = WorkPosition.Text;
		WorkPosition.Text = "";
		user.Education = Education.Text;
		Education.Text = "";
		user.Password = Password.Text;
		Password.Text = "";
        await initDatabase.SaveItemAsync(user);

        await DisplayAlert("Alert", "Succesfoul registration", "ok");
		await Navigation.PopAsync();
    }
}