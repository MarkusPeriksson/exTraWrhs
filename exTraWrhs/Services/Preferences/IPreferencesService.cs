using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTraWrhs.Services.Preferences
{
    public interface IPreferencesService
    {
        void SavePreferences(string key, string value);
        void SavePreferences(string key, bool value);
        string GetPreferences(string key, string defaultValue);
        bool GetPreferences(string key, bool defaultValue);
    }
}
