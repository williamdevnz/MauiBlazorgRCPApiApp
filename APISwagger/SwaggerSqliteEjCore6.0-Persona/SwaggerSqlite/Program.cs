using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SwaggerSqlite.Data;
using SwaggerSqlite.Domain;

namespace SwaggerSqlite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // CreateHostBuilder(args).Build().MigrateDatabase().Run();
            var host = CreateHostBuilder(args).Build();

            //// Migrar la tabla Departamentos
            host.MigrateDatabase<Departamentos>();
            // Migrar la tabla Empleados
            host.MigrateDatabase<Empleados>();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<TodoContext<Departamentos>>();
            //    await context.Database.MigrateAsync();
            //}

            //// Migrar la base de datos para Empleados
            //using (var scope = host.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<TodoContext<Empleados>>();
            //    await context.Database.MigrateAsync();
            //}


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}