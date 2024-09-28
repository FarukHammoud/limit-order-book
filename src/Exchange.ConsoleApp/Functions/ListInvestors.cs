using DustInTheWind.ConsoleTools.Controls;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public static class ListInvestors {
        public static void Display(Exchange exchange, Callback callback) {
            var investors = exchange.GetInvestors()
                    .ToList();
            var textBlock = new TextBlock() {
                Text = investors.Count == 0 ? "None" : String.Concat(investors)
            };
            textBlock.Display();
            Pause.QuickDisplay("Enter to Continue");
            Console.Clear();
            callback();
        }
    }
}
