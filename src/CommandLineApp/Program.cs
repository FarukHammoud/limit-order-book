using Application;
using CommandLineApp;
using InfrastructureExchange;   

static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args) {
        CommandLineInput commandLineInput = new(args);
        IEnumerable<OrderRequest> orders = commandLineInput.GetOrders();
        Exchange exchange = new();
        Security security = new() { 
            Code = "X", 
            Name = "X"};
        OrderBookParameters orderBookParameters = new();
        exchange.AddTradedSecurity(security, orderBookParameters);
        ExchangeInputer inputer = new(exchange);
        inputer.Input(orders, security);
    }
}
