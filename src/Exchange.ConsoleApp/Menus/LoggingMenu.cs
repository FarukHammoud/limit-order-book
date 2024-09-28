using ConsoleAppLibrary;
using ExchangeConsoleApp;
using InfrastructureExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExchangeConsoleApp.Menus {
    public static class LoggingMenu {
        public static void Display(Exchange exchange, Callback callback) {
            Menu menu = new() {
                Title = "Logging",
                Items = new[] {
                    new MenuItem() {
                        Text = "Last Transactions by Security",
                        Handler = () => ListTradedSecurities.Display(exchange, callback)
                    },
                    new MenuItem() {
                        Text = "Last Transactions by Investor",
                        Handler = () => AddTradedSecurity.Display(exchange, callback)
                    }
                }
            };
            menu.Display();
        }
    }
}
