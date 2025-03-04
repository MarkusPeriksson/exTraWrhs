using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTraWrhs.Services.Preferences
{
    public class PreferencesService : IPreferencesService
    {
        public string GetPreferences(string key, string defaultValue)
        {
            return Microsoft.Maui.Storage.Preferences.Get(key, defaultValue);
        }

        public bool GetPreferences(string key, bool defaultValue)
        {
            return Microsoft.Maui.Storage.Preferences.Get(key, defaultValue);
        }

        public void SavePreferences(string key, string value)
        {
            Microsoft.Maui.Storage.Preferences.Set(key, value);
        }

        public void SavePreferences(string key, bool value)
        {
            Microsoft.Maui.Storage.Preferences.Set(key, value);
        }
    }
}
