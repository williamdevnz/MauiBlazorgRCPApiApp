using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using MauiBlazorgRCPApiApp.Data;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using ProtoBuf.Grpc.Client;
using DataView2.Core.Models;
using AutoMapper;
using MauiBlazorgRCPApiApp.Models;
using CommunityToolkit.Maui;
using Microsoft.AspNetCore.Components;

namespace MauiBlazorgRCPApiApp
{

    public static class MauiProgram
    {
        [Inject] private static NavigationManager NavigationManager { get; set; }
        public static MauiApp CreateMauiApp()
        {
            
                string BaseAddress = "http://localhost:5042";
                //Seccion Mapper:
                var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<PersonaProfile>();
                    // Agrega otros perfiles de mapeo aquí si los tienes.
                });
                var mapper = mapperConfig.CreateMapper();
                var builder = MauiApp.CreateBuilder();
            try
            {
                builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                }).UseMauiCommunityToolkit();
                builder.Services.AddMauiBlazorWebView();
                builder.Services.AddMudServices();
#if DEBUG
                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();
#endif
                builder.Services.AddSingleton<WeatherForecastService>();
                //Adicion Mapper: 
                builder.Services.AddSingleton(mapper);
                builder.Services.AddSingleton(services =>
                {
                    var httpHandler = new GrpcWebHandler(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
                    var channel = GrpcChannel.ForAddress(BaseAddress, new GrpcChannelOptions { HttpHandler = httpHandler });
                    return channel.CreateGrpcService<ISettingsService>();
                });
            }
            catch(Exception ex)
            {
                NavigationManager.NavigateTo($"/error?message={Uri.EscapeDataString(ex.Message)}");
            }
            return builder.Build();
        }
    }
}