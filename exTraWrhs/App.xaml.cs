using exTraWrhs.Services.Navigation;

namespace exTraWrhs
{
    public partial class App : Application
    {
        public App(INavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}
