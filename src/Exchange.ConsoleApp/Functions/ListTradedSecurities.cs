using DustInTheWind.ConsoleTools.Controls;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public static class ListTradedSecurities {
        public static void Display(Exchange exchange, Callback callback) {
            var tradedSecurities = exchange.GetTradedSecurities()
                    .Select(s => $"{s.Code}: {s.Name}")
                    .ToList();
            var textBlock = new TextBlock() {
                Text = tradedSecurities.Count == 0 ? "None" : String.Concat(tradedSecurities)
            };
            textBlock.Display();
            Pause.QuickDisplay("Enter to Continue");
            Console.Clear();
            callback();
        }
    }
}
