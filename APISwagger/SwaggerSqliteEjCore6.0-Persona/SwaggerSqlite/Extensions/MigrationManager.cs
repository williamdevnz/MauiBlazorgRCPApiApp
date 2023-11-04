using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SwaggerSqlite.Data;
using SwaggerSqlite.Domain;
using System;

namespace SwaggerSqlite
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase<T>(this IHost host) where T : class
        {
            using (var scope = host.Services.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<TodoContext<T>>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred configuring the DB.");
                }
            }

            return host;
        }

    }
}
