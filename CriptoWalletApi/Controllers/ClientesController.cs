using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CriptoWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            List<Cliente> listaClientes;

            try
            {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    listaClientes = context.Clientes.ToList();
                }
             
                return listaClientes;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Cliente>();
            }           
        }

        // GET api/<ClientesController>/5
        [Route("GetById")]
        [HttpGet()]
        public Cliente Get(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                Cliente? clienteSelect = context.Clientes.FirstOrDefault(cl => cl.IdCliente == id);
                return clienteSelect;
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var clienteSelect = context.Clientes.FirstOrDefault(cl=> cl.IdCliente == cliente.IdCliente);
                clienteSelect = cliente;
                context.SaveChanges();
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(Cliente cliente)
        {
            try
            {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    Cliente? clienteAEliminar = context.Clientes.FirstOrDefault(cl => cl.IdCliente == cliente.IdCliente);
                    context.Clientes.Remove(clienteAEliminar);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
