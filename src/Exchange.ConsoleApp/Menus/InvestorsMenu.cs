using ConsoleAppLibrary;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public static class InvestorsMenu {
        public static void Display(Exchange exchange, Callback callback) {
            Menu menu = new() {
                Title = "Investors",
                Items = new[] {
                    new MenuItem() {
                        Text = "Get Investors List",
                        Handler = () => ListInvestors.Display(exchange, callback)
                    },
                    new MenuItem() {
                        Text = "Remove Investor",
                        Handler = () => RemoveInvestor.Display(exchange, callback)
                    }
                }
            };
            menu.Display();
        }
    }
}
