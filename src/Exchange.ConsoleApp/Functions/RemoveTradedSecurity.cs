using DustInTheWind.ConsoleTools.Controls.InputControls;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public class RemoveTradedSecurity {
        public static void Display(Exchange exchange, Callback callback) {
            Console.Clear();
            string code = ValueControl<string>.QuickRead("Code:");
            if (exchange.GetTradedSecurities().Select(s => s.Code).ToList().Contains(code)) {
                Fail.Display("Code not listed", callback);
            }
            exchange.RemoveTradedSecurity(code);
            Success.Display("Security Removed", callback);
        }
    }
}
