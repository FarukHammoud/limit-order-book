using Application;
using InfrastructureExchange;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBookController : ControllerBase {
        private readonly ILogger<OrderBookController> _logger;
        private readonly IExchange _exchange;

        public OrderBookController(ILogger<OrderBookController> logger,
                                  IExchange exchange) {
            _logger = logger;
            _exchange = exchange;
        }

        [HttpPost(Name = "GetOrderBook")]
        public IOrderBook? GetOrderBook(string code) {
            var securities = _exchange.GetTradedSecurities();
            var security = securities.FirstOrDefault(
                x => x.Code == code);
            if (security != null) {
                return _exchange.GetOrderBook(security);
            }
            return null;
        }
    }
}
