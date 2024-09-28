using Application;
using InfrastructureExchange;

namespace Client.BlazorWebAssembly {
    public class SecurityL1ViewModel {
        public string SecurityName => _security.Name;
        public string SecurityCode => _security.Code;
        public double Price => 1.37820;
        public double Variation => -0.00470;
        public double VariationPercentage => Variation/Price;
        public double High => 1.38620;
        public double Low => 1.37725;
        public double BidVolume => 2e6;
        public double Bid => 1.37815;
        public double AskVolume => 2e6;
        public double Ask => 1.37820;

        private readonly Security _security;
        private readonly Exchange _exchange;
        private IOrderBook orderBook => _exchange.GetOrderBook(_security);

        public SecurityL1ViewModel(Security security, Exchange exchange) { 
            _security = security;
            _exchange = exchange;
        }
       
    }
}
