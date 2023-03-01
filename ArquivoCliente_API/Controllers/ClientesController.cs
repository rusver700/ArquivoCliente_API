using ArquivoCliente_API.Modelo;
using ArquivoCliente_API.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ArquivoCliente_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteServico _clienteServico;

        public ClientesController(ClienteServico clienteServico)
        {
          _clienteServico= clienteServico;
        }

        [HttpGet]
        public async Task<List<Cliente>> GetClientes()
            => await _clienteServico.GetAsync();


        [HttpGet("id")]
        public async Task<Cliente> GetClienteId(string id) => await _clienteServico.GetAsync(id);

        [HttpPost]
        public async Task<Cliente> PostCliente(Cliente cliente)
        {
            await _clienteServico.CreateAsync(cliente);

            return cliente;
        }
      
        [HttpPut]
        public async Task<Cliente> PutCliente(string id, Cliente cliente)
        {
            await _clienteServico.UpdateAsync(id, cliente);

            return cliente;
        }
        [HttpDelete]
        public async Task DeleteCliente(string id)
        {
            await _clienteServico.RemoveAsync(id);
        }
    }
}

