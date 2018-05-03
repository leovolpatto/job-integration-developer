using IntelipostMiddleware.Integrations.Intelipost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelipostMiddleware.API
{
    /// <summary>
    /// API para testes para simular a plataforma de vendas. (Os posts neste serviço serão feitas aqui)
    /// </summary>
    [Route("api/[controller]")]
    public class _SalePlatformTestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Servico de teste da Plataforma de vendas.";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderTrackingInformation value)
        {
            return this.Ok();//se chegou aqui, retorna 200 (case desse erro a API do middleware iria tratar )
        }
    }
}
