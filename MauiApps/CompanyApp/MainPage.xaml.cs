namespace CompanyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public  InitDatabase InitDatabase { get; set; }

        public MainPage()
        {
            InitializeComponent();
            InitDatabase = new InitDatabase();
            
            
        }
        private List<User> users = new List<User>();
        public List<User> customList { get { return users; } set { users = value; OnPropertyChanged(); } }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void ContentPage_AppearingAsync(object sender, EventArgs e)
        {
            customList = await InitDatabase.GetItemsAsync();
            BindingContext = this;
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
    public class Test
    {
        public string MyProperty { get; set; }
    }
}