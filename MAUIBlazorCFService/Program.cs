using MAUIBlazorCFService.Data;
using MAUIBlazorCFService.Interfaces;
using MAUIBlazorCFService.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=Empresa.db"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal; });

builder.Services.AddGrpc();

//builder.Services.AddGrpcReflection(); //Para probar el servicio desde Postman. Se instala con Nuggets primero.

var app = builder.Build();

//**************Para Postman:
//IWebHostEnvironment env = app.Environment;

//if (env.IsDevelopment())
//{
//    app.MapGrpcReflectionService();
//}
//app.UseGrpcWeb();
//***************************************
// Configure the HTTP request pipeline.
app.MapGrpcService<PersonaService>();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//app.UseRouting();
//app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGrpcService<PersonaService>().EnableGrpcWeb();  // Habilitar gRPC-Web para tu servicio
//    endpoints.MapGrpcReflectionService();  // Añadir esta línea
//    endpoints.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
//});



app.Run();


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();
