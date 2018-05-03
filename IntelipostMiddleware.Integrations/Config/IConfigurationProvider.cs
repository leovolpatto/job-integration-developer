using IntelipostMiddleware.Integrations.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelipostMiddleware.Integrations.Config
{
    public interface IConfigurationProvider
    {
        Configuration GetConfiguration();
    }
}
