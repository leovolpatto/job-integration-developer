using IntelipostMiddleware.Integrations.Config;
using IntelipostMiddleware.Integrations.External;
using IntelipostMiddleware.Integrations.Intelipost.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static IntelipostMiddleware.Integrations.External.IntegrationProxyArgs;

namespace IntelipostMiddleware.API
{
    /// <summary>
    /// Serviço interno - precisa de autenticacao?!
    /// </summary>
    [Route("api/[controller]")]
    public class TrackingController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Tracking endpoint. Service is running";//só para ajudar em testes. Caso contrario seria 404
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderTrackingInformation value)
        {
            TrackingValidationManager validator = new TrackingValidationManager(this, value);
            if (!validator.Validate(this.ModelState))
            {
                return this.BadRequest(this.ModelState);
            }

            var args = new IntegrationProxyArgsBuilder()
                .SetPlatformType(SuportedPlatforms.SalePlatform)
                .SetBaseURI("/api")
                .Build();

            var result = IntegrationProxy.GetInstance(args)
                .Proxy.SendTrackNotification(value);

            if (!result.IsSuccess)
            {
                return this.BadRequest(result.Message);
            }

            return this.Ok("Platform was notified successfully");
        }        
    }
}
