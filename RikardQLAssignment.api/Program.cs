using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RikardQLAssignment.api.DataAccess;

namespace RikardQLAssignment.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            using (var dbContext = scope.ServiceProvider.GetService<DataBaseContext>())
            {
                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Migration of database failed");
                    throw;
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}