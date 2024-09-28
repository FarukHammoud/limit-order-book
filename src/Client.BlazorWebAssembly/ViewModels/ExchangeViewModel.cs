using Application;
using InfrastructureExchange;

namespace Client.BlazorWebAssembly {
    public class ExchangeViewModel {
        private Exchange _exchange;
        public Dictionary<Security, OrderBookViewModel> OrderBookViewModels { get; } = new();
        public ExchangeViewModel() {
            var securities = _exchange.GetTradedSecurities();

        }
    }
}
