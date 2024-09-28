using Application;
using InfrastructureExchange;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi {
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase {
        private readonly ILogger<InvestorController> _logger;
        private readonly IExchange _exchange;

        public InvestorController(ILogger<InvestorController> logger,
                            IExchange exchange) {
            _logger = logger;
            _exchange = exchange;
        }

        [HttpPost(Name = "PostInvestor")]
        public void PostInvestor(string name) {
            _exchange.RegisterInvestor(name);
        }
    }
}
