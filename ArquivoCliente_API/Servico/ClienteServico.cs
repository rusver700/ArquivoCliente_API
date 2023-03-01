using ArquivoCliente_API.Modelo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ArquivoCliente_API.Servico
{
    public class ClienteServico
    {
        private readonly IMongoCollection<Cliente> _clienteCollection;

        public ClienteServico(IOptions<ClienteDatabaseSettings> clienteServices)
        {
            var mongoClient = new MongoClient(clienteServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(clienteServices.Value.DatabaseName);

            _clienteCollection = mongoDatabase.GetCollection<Cliente>
                (clienteServices.Value.ClienteCollection);

        }

        public async Task<List<Cliente>> GetAsync() =>
            await _clienteCollection.Find(x => true).ToListAsync();
        public async Task<Cliente> GetAsync(string id) =>
           await _clienteCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Cliente cliente) =>
            await _clienteCollection.InsertOneAsync(cliente);
        public async Task UpdateAsync(string id, Cliente cliente) =>
           await _clienteCollection.ReplaceOneAsync(x => x.Id == id, cliente);
        public async Task RemoveAsync(string id) =>
            await _clienteCollection.DeleteOneAsync(x => x.Id == id);
    }
}
