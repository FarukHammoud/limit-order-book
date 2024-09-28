using Application;
using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.InputControls;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp.Functions {
    public class LastTransactionsBySecurity {
        public void Display(Exchange exchange, Callback callback) {
            Console.Clear();
            string code = ValueControl<string>.QuickRead("Code:");
            var security = exchange.GetTradedSecurities().FirstOrDefault(s => s.Code.ToLower() == code.ToLower());
            if (security == null) {
                Fail.Display("Code not listed", callback);
                return;
            }
            IOrderBookLogger logger =  exchange.GetLogger(security);
            var textBlock = new TextBlock() {
                Text = ""
            };
            textBlock.Display();
            Success.Display("", callback);
        }
    }
}
