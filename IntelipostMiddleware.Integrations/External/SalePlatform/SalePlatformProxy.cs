using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IntelipostMiddleware.Integrations.Config;
using IntelipostMiddleware.Integrations.External.SalePlatform.Adapters;
using IntelipostMiddleware.Integrations.External.SalePlatform.Responses;
using IntelipostMiddleware.Integrations.Intelipost.Models;
using Newtonsoft.Json;

namespace IntelipostMiddleware.Integrations.External.SalePlatform
{
    public sealed class SalePlatformProxy : IPlatformProxy
    {
        public SendTrackNotificationResult SendTrackNotification(OrderTrackingInformation orderTrackingInformation)
        {
            OrderTrackingInfoAdapter adaptee = new OrderTrackingInfoAdapter();

            using (var client = new HttpClient())
            {
                /*
                 * Autenticacao pode ser feita aqui
                 */
                var url = ServiceConfiguration.GetConfigurations()
                    .Configuration
                    .GetConfiguration()
                    .ApiUrl;

                HttpResponseMessage response = null;
                try
                {
                    response = client.PostAsync(url, new JsonContent(adaptee.Adapt(orderTrackingInformation))).Result;
                }
                catch (Exception ex)
                {
                    return new SendTrackNotificationResult(response);
                }

                return new SendTrackNotificationResult(response);
            }
        }

        public class JsonContent : StringContent
        {
            public JsonContent(object value) : base(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json")
            {
            }
        }
    }


}
