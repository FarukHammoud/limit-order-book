using Application;
using InfrastructureExchange;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi {
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritiesController : ControllerBase {
        private readonly ILogger<SecuritiesController> _logger;
        private readonly IExchange _exchange;

        public SecuritiesController(ILogger<SecuritiesController> logger,
                                  IExchange exchange) {
            _logger = logger;
            _exchange = exchange;
        }

        [HttpGet(Name = "GetTradedSecurities")]
        public IEnumerable<Security> GetTradedSecurities() {
            return _exchange.GetTradedSecurities();
        }
    }
}
