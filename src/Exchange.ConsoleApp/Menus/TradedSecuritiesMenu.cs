using ConsoleAppLibrary;
using ExchangeConsoleApp;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp.Menus {
    public static class TradedSecuritiesMenu {
        public static void Display(Exchange exchange, Callback callback) {
            Menu menu = new() {
                Title = "Traded Securities",
                Items = new[] {
                    new MenuItem() {
                        Text = "List Traded Securities",
                        Handler = () => ListTradedSecurities.Display(exchange, callback)
                    },
                    new MenuItem() {
                        Text = "Add Traded Security",
                        Handler = () => AddTradedSecurity.Display(exchange, callback)
                    },
                    new MenuItem() {
                        Text = "Remove Traded Securities",
                        Handler = () => RemoveTradedSecurity.Display(exchange, callback)
                    }
                }
            };
            menu.Display();
        }
    }
}
