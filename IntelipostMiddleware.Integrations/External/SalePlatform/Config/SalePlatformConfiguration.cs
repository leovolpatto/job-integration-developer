using IntelipostMiddleware.Integrations.Config;

namespace IntelipostMiddleware.Integrations.External.SalePlatform.Config
{
    public class SalePlatformConfiguration : HardCodedConfiguration
    {
        public override Configuration GetConfiguration()
        {
            return new Configuration()
            {
                ApiUrl = "http://localhost:5000/api/saleplatform"
            };
        }
    }
}
