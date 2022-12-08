using CriptoWalletApi.DTO;
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
        public void Post([FromBody] ClienteDTO cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                context.Clientes.Add(new Cliente
                {   
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Domicilio = cliente.Domicilio,
                    Email = cliente.Email,
                    Password = cliente.Password,
                    Estado = cliente.Estado,
                    IdLocalidad = cliente.IdLocalidad,
                    
                });                
                context.SaveChanges();
            }
        }

        // POST api/<ClientesController>
        [Route("Login")]
        [HttpPost]
        public Cliente Login([FromBody] LoginDTO login)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {

                var clientSelect = context.Clientes.FirstOrDefault(cl => cl.Email== login.Email && cl.Password == login.Password);
                if (clientSelect != null)
                {
                    var cuentas = context.CuentasBancarias.FirstOrDefault(cu => cu.IdCliente == clientSelect.IdCliente);
                    var transacciones = context.Transacciones.FirstOrDefault(tr => tr.IdCuenta == cuentas.IdCuenta);
                    cuentas.Transacciones.Add(transacciones);
                    clientSelect.CuentasBancaria.Add(cuentas);
              
                   
                }
            return clientSelect;
            }


        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public void Put([FromBody] ClienteDTO cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var clienteSelect = context.Clientes.FirstOrDefault(cl => cl.IdCliente == cliente.IdCliente);
                clienteSelect.Email = cliente.Email;
                clienteSelect.Domicilio = cliente.Domicilio;
                context.SaveChanges();
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    Cliente? clienteAEliminar = context.Clientes.FirstOrDefault(cl => cl.IdCliente == id);
                    clienteAEliminar.Estado = false;
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
