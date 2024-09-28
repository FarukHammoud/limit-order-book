using ClientExchangeConsoleApp.Menus;
using InfrastructureExchange;

namespace ClientExchangeConsoleApp {
    public static class ConsoleApplication {
        private static Exchange _exchange = new();
        public static void Run() {
            MainMenu.Display(_exchange);
        }
    }
}
