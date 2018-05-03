using IntelipostMiddleware.Integrations.External.SalePlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelipostMiddleware.Integrations.External
{
    class IntegrationProxyFactory
    {
        public IPlatformProxy CreateProxy(IntegrationProxyArgs args)
        {
            if(args.Platform == SuportedPlatforms.SalePlatform)
            {
                return new SalePlatformProxy();
            }//se houvessem varias, daria para decorar os Proxies e buscar o correto por reflection, eliminando condicionais

            throw new PlatformNotSupportedException("Not supported platform");
        }
    }
}
