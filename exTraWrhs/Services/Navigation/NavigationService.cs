using exTraWrhs.Services.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTraWrhs.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IPreferencesService _preferencesService;
        public NavigationService(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        public Task InitializeAsync() =>
            NavigateToAsync(
                string.IsNullOrEmpty(_preferencesService.GetPreferences("extraUser", string.Empty)) &&
                string.IsNullOrEmpty(_preferencesService.GetPreferences("extraPassword", string.Empty))
                ? "//MainView"
                : "//MainView");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
