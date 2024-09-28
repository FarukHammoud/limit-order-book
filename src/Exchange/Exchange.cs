using Application;

namespace InfrastructureExchange {
    public class Exchange : IExchange, IExchangeAdmin {
        private readonly Dictionary<Security, OrderBook> _orderBooks = new();
        private readonly Dictionary<Security, IOrderBookLogger> _loggers = new();
        private readonly Dictionary<string, InvestorId> _investors = new();

        public void AddTradedSecurity(Security security,
                                      OrderBookParameters parameters) {
            if (!_orderBooks.ContainsKey(security)) {
                var logger = new Logger();
                _loggers[security] = logger;
                _orderBooks[security] =  new OrderBook(parameters, logger);
            } else {
                throw new KeyNotFoundException("Non-registered Security");
            }
        }

        public void RemoveTradedSecurity(string code) {
            if (!_orderBooks.Keys.Select(s => s.Code).ToList().Contains(code)) {
                throw new KeyNotFoundException("Security not registered");
            }
            var security = _orderBooks.First(s => s.Key.Code == code).Key;
            _orderBooks.Remove(security);
        }

        public IOrderBook GetOrderBook(Security security) {
            if (_orderBooks.ContainsKey(security)) {
                return _orderBooks[security];
            }
            throw new KeyNotFoundException();
        }

        public IList<Security> GetTradedSecurities() {
            return _orderBooks.Keys.ToList();
        }

        public InvestorId RegisterInvestor(string name) {
            if (!_investors.ContainsKey(name)) {
                _investors[name] = new InvestorId();
                return _investors[name];
            } else {
                throw new KeyNotFoundException("Investor already registered");
            }
        }

        public IList<(string, InvestorId)> GetInvestors() {
            return _investors.Keys.ToList().Select(key => (key, _investors[key])).ToList();
        }

        public IOrderBookLogger GetLogger(Security security) {
            return _loggers[security];
        }

        public void RemoveInvestor(string name) {
            if (!_investors.ContainsKey(name)) {
                throw new ArgumentException("Investor not registered");
            } 
            _investors.Remove(name);
        }
    }
}
