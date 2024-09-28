using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppLibrary {
    public static class ServiceCollectionExtensions {
        public static void AddFormsService(this IServiceCollection services) {
            services.AddSingleton<IFormsTypeHandler, DoubleFormsHandler>();
            services.AddSingleton<IFormsTypeHandler, StringFormsHandler>();
            services.AddSingleton<FormsService>();
        }
    }
}
