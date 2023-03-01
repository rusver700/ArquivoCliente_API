namespace ArquivoCliente_API.Modelo
{
    public class ClienteDatabaseSettings
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
        public string ClienteCollection { get; set; } = default!;
    }
}
