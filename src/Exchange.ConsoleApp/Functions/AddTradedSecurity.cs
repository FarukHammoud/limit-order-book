using Application;
using ClientExchangeConsoleApp;
using ConsoleAppLibrary;
using DustInTheWind.ConsoleTools.Controls.InputControls;
using InfrastructureExchange;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeConsoleApp {
    public class AddTradedSecurity {
        public static void Display(Exchange exchange, Callback callback) {
            Console.Clear();
            var handlers = ServiceProviderFactory.ServiceProvider
                .GetServices(typeof(IFormsTypeHandler));
            Security userSecurity = (new FormsService((IList<IFormsTypeHandler>)handlers)).Display<Security>();
            YesNoQuestion defaultParametersQuestion = new YesNoQuestion("Default Order Book Parameters?");
            bool defaultParameters = defaultParametersQuestion.ReadAnswer() == YesNoAnswer.Yes;
            if (!defaultParameters) {
                throw new NotImplementedException();
            }
            foreach (var security in exchange.GetTradedSecurities()) {
                if (security.Name.Equals(userSecurity.Name) || security.Code.Equals(userSecurity.Code)) {
                    Fail.Display("Name or Code already registered", callback);
                    callback();
                    return;
                }
            }
            exchange.AddTradedSecurity(userSecurity, new OrderBookParameters());
            Success.Display("Security Added", callback);
        }
    }
}
