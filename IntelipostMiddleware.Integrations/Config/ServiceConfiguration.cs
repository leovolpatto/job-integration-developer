using IntelipostMiddleware.Integrations.External;
using IntelipostMiddleware.Integrations.External.SalePlatform.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelipostMiddleware.Integrations.Config
{
    public class ServiceConfiguration
    {
        private static ServiceConfiguration _instance;
        private SuportedPlatforms platform;

        private ServiceConfiguration()
        {
            this.LoadConfigurations();
        }

        public static ServiceConfiguration GetConfigurations(SuportedPlatforms platform = SuportedPlatforms.SalePlatform)
        {
            if(_instance == null)
            {
                _instance = new ServiceConfiguration();
                _instance.platform = platform;
            }

            return _instance;
        }
        
        private void LoadConfigurations()
        {
            this.Configuration = new SalePlatformConfiguration();
            //se forem muitas, usar reflection
        }

        public IConfigurationProvider Configuration { get; private set; }
    }
}
