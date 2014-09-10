using System.Configuration;
using AcceptanceTesting.Common;

namespace AcceptanceTesting.Specs.Infrastructure
{
    public class Settings
    {
        public string BaseUrl
        {
            get { return GetAppSetting("baseUrl"); }
        }

        public string ValidUserName
        {
            get { return GetDecryptedSetting("validUserName"); }
        }

        public string ValidPassword
        {
            get { return GetDecryptedSetting("validPassword"); }
        }

        private string GetDecryptedSetting(string key)
        {
            return GetAppSetting(key).Decrypt();
        }

        private string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
