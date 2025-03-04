using exTraWrhs.Services.Navigation;
using exTraWrhs.Views;

namespace exTraWrhs
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AppShell.InitializeRouting();

            InitializeComponent();
        }

        private static void InitializeRouting()
        {
            Routing.RegisterRoute("Prikupljanje", typeof(PrikupljanjeView));
            Routing.RegisterRoute("Pakiranje", typeof(PakiranjeView));
            Routing.RegisterRoute("Inventura", typeof(InventuraView));
            Routing.RegisterRoute("Zapisnik", typeof(ZapisnikView));
            Routing.RegisterRoute("Osnovna sredstva", typeof(OsnovnaSredstvaView));
            Routing.RegisterRoute("Stanje", typeof(StanjeView));
            Routing.RegisterRoute("EMVS", typeof(EMVSView));
            Routing.RegisterRoute("Administracija sustava", typeof(AdministracijaView));
        }
    }
}
