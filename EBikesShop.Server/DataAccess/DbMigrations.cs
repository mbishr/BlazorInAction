using System;
using EBikeShop.Server;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace EBikesShop.Server
{
    public class DbMigrations
    {
        private readonly IDbSession _dbSession;

        public DbMigrations(IDbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public void Run()
        {
            var serviceProvider = CreateServices();
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSQLite()
                    // Set the connection string
                    .WithGlobalConnectionString(_dbSession.GetConnectionString())
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(AddStateTaxTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
