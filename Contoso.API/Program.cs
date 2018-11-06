using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contoso.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Contoso.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // REPLACE THIS:
            // BuildWebHost(args).Run();

            // WITH THIS:
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                // Retrieve your DbContext isntance here
                var dbContext = scope.ServiceProvider.GetService<ContosoContext>();

            }
            host.Run();

            // ref.: https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
