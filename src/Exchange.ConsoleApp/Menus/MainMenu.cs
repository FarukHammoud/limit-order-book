using ConsoleAppLibrary;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp.Menus {
    public class MainMenu {
        public static void Display(Exchange exchange) {
            Menu menu = new() {
                Title = "Exchange Console",
                Items = new[] {
                    new MenuItem() {
                        Text = "Traded Securities",
                        Handler = () => TradedSecuritiesMenu.Display(exchange, () => { Display(exchange); })
                    },
                    new MenuItem() {
                        Text = "Investors",
                        Handler = () => InvestorsMenu.Display(exchange, () => { Display(exchange); })
                    },
                    new MenuItem() {
                        Text = "Logging",
                        Handler = () => LoggingMenu.Display(exchange, () => { Display(exchange); })
                    }
                }
            };
            menu.Display();
        }
    }
}
