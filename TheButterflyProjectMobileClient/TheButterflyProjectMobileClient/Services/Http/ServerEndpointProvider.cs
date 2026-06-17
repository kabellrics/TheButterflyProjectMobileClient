using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Contracts;

namespace TheButterflyProjectMobileClient.Services.Http
{
    public class ServerEndpointProvider : IServerEndpointProvider
    {
        private const string SettingsKey = "ServerAdress";
        private const string ServerDefault = "https://localhost:8000";

        public string ServerAdressString
        {
            get => Preferences.Get(SettingsKey, ServerDefault);
            set => Preferences.Set(SettingsKey, value);
        }
    }
}
