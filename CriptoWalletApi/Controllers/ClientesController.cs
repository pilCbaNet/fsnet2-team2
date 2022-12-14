using CriptoWalletApi.DTO;
using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CriptoWalletApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        /// <summary>
        /// Recupera una lista de clientes registrados en la plataforma.
        /// </summary>
        /// <returns>Lista de clientes</returns>

        [HttpGet]
        [Produces(typeof(List<Cliente>))]
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
        /// <summary>
        /// Recupera un cliente según el ID pasado por parámetro.
        /// </summary>
        /// <param name="id">ID de Cliente</param>
        /// <returns>Cliente registrado en la plataforma</returns>

        [Route("GetById")]
        [HttpGet()]
        [Produces(typeof(Cliente))]
        public Cliente Get(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                Cliente? clienteSelect = context.Clientes.FirstOrDefault(cl => cl.IdCliente == id);
                return clienteSelect;
            }
        }

        // POST api/<ClientesController>
        /// <summary>
        /// Creación y registro de un cliente en la plataforma.
        /// </summary>
        /// <param name="cliente"> Cliente</param>

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
        /// <summary>
        /// Registro de un nuevo usuario, su logueo produce la creación de una cuenta.
        /// </summary>
        /// <param name="login">Usuario y Password del cliente</param>
        /// <returns>Cliente registrado y creación de una cuenta</returns>

        [Route("Login")]
        [HttpPost]
        [Produces(typeof(Cliente))]
        public Cliente Login([FromBody] LoginDTO login)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {

                var clientSelect = context.Clientes.FirstOrDefault(cl => cl.Email== login.Email && cl.Password == login.Password);
                if (clientSelect != null)
                {
                    var cuentas = context.CuentasBancarias.FirstOrDefault(cu => cu.IdCliente == clientSelect.IdCliente);
                    if (cuentas != null)
                    {
                        var transacciones = context.Transacciones.FirstOrDefault(tr => tr.IdCuenta == cuentas.IdCuenta);
                        cuentas.Transacciones.Add(transacciones); 
                        clientSelect.CuentasBancaria.Add(cuentas);  
                        return clientSelect;
                    }
                    if(cuentas == null)
                    {
                        var rd = new Random();
                        cuentas = new CuentasBancaria()
                        {
                            Alias = clientSelect.Nombre + "." + clientSelect.Apellido,
                            Cbu = 0,
                            IdCliente = clientSelect.IdCliente,
                            Estado = clientSelect.Estado,
                            IdCuenta = 0,
                            Monto = 0,
                            Transacciones = new Transaccione[0],
                            NumeroDeCuenta = rd.Next(100000000, 999999999)
                            
                        };
                        
                        clientSelect.CuentasBancaria.Add(cuentas);
                        context.SaveChanges();
                    }
                }
            return clientSelect;
            }


        }

        // PUT api/<ClientesController>/5
        /// <summary>
        /// Actualización de los atributos de un cliente, localizado por ID.
        /// </summary>
        /// <param name="cliente">Cliente a actualizar</param>

        [HttpPut]
        [Produces(typeof(Cliente))]
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
        /// <summary>
        /// Eliminación física de un cliente localizado por ID.
        /// </summary>
        /// <param name="id">ID del Cliente</param>

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
