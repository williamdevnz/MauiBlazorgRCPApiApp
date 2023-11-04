using Grpc.Net.Client;


namespace MauiBlazorgRCPApiApp.Logic
{
    public class ClientgRPC
    {
        //private readonly Crudpersona.CrudpersonaClient;

        //public ClientgRPC(string gRCPUrl)
        //{
        //    // Dirección del servidor gRPC (puedes cambiarla según tu configuración).
        //    //string serverAddress = "localhost:50051";
        //    //using var channel = GrpcChannel.ForAddress("http://localhost:5244/");
        //    //{
        //    //    // var client = new ProtoConsolePersona.CrudPersona.CrudPersonaClient(channel);
        //    //    //var personasResponse = client.GetPersonas(new CGetPersonaRequest());
        //    //    //foreach (var persona in personasResponse.Personas)
        //    //    //{
        //    //    //    Console.WriteLine($"ID: {persona.IdPersona}, Nombre: {persona.Nombres} {persona.Apellidos}");
        //    //    //}
        //    //}



        //    // Crear un canal gRPC para conectarse al servidor.
        //    //Channel channel = new Channel(serverAddress, ChannelCredentials.Insecure);

        //    //// Crear el cliente gRPC para el servicio CRUD de Persona.
        //    //_client = new CrudPersona.CrudPersonaClient(channel);
        //}

        //public async Task<List<Persona>> GetPersonasAsync()
        //{
        //    try
        //    {
        //        // Ejemplo de llamada a GetPersonas:
        //        var personasResponse = await _client.GetPersonasAsync(new CGetPersonaRequest());

        //        return personasResponse.Personas.ToList();
        //    }
        //    catch (RpcException ex)
        //    {
        //        Console.WriteLine($"Error en la comunicación gRPC: {ex.Status}");
        //        return new List<Persona>();
        //    }
        //}
    }
}
