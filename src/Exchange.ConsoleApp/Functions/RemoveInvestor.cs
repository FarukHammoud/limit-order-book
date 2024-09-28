using DustInTheWind.ConsoleTools.Controls.InputControls;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public class RemoveInvestor {
        public static void Display(Exchange exchange, Callback callback) {
            Console.Clear();
            string name = ValueControl<string>.QuickRead("Investor Name:");
            if (!exchange.GetInvestors().Select(s => s.Item1).ToList().Contains(name)) {
                Fail.Display("Investor Name not registered", callback);
                return;
            }
            exchange.RegisterInvestor(name);
            Success.Display("Investor Removed", callback);
        }
    }
}
