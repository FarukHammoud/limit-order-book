using Application;
using InfrastructureExchange;

namespace CommandLineApp {
    public class ExchangeInputer {
        private readonly Exchange _exchange;
        public ExchangeInputer(Exchange exchange) {
            _exchange = exchange;
        }

        public void Input(IEnumerable<OrderRequest> orders, Security security) {
            IOrderBook orderBook = _exchange.GetOrderBook(security); 
            foreach (OrderRequest? order in orders) {
                if (order != null) {
                    if (!_exchange.GetInvestors().Where(e => e.Item1 == order.InvestorCode).Any()) {
                        Console.WriteLine($"Registering new investor : {order.InvestorCode}");
                        _exchange.RegisterInvestor(order.InvestorCode);
                    }
                    orderBook.Add(order);
                    orderBook.Execute();
                }
            }
        }
    }
}
