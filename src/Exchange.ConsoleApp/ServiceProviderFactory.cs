using Microsoft.Extensions.DependencyInjection;

namespace ClientExchangeConsoleApp {
    public static class ServiceProviderFactory {
        public static IServiceProvider ServiceProvider { get; }

        static ServiceProviderFactory() {
            Startup startup = new Startup();
            ServiceCollection sc = new ServiceCollection();
            startup.ConfigureServices(sc);
            ServiceProvider = sc.BuildServiceProvider();
        }
    }
}
