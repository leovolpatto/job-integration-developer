using System;
using System.Collections.Generic;
using System.Text;
using IntelipostMiddleware.Integrations.External;

namespace IntelipostMiddleware.Integrations.Config
{
    public abstract class HardCodedConfiguration : IConfigurationProvider
    {
        public abstract Configuration GetConfiguration();
    }
}
