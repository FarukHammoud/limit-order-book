﻿using Microsoft.Extensions.DependencyInjection;
using ConsoleAppLibrary;

namespace ClientExchangeConsoleApp {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddFormsService();
        }
    }
}
