using IntelipostMiddleware.Integrations.External.SalePlatform.Responses;
using IntelipostMiddleware.Integrations.Intelipost.Models;

namespace IntelipostMiddleware.Integrations.External
{
    /// <summary>
    /// Interface que define quais operações podem ser executadas em todas as integracoes
    /// </summary>
    public interface IPlatformProxy
    {
        SendTrackNotificationResult SendTrackNotification(OrderTrackingInformation orderTrackingInformation);

        /** Adicionar outras operações  que forem necessárias **/ 
    }
}
