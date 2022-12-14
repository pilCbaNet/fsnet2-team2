using CriptoWalletApi.DTO;
using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace CriptoWalletApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {

        // GET: api/<CuentasController>
        /// <summary>
        /// Recupera una lista de cuentas bancarias registrados en la plataforma.
        /// </summary>
        /// <returns>Lista de cuentas bancarias</returns>
        [HttpGet]
        [Produces(typeof(List<Cliente>))]
        public IEnumerable<CuentasBancaria> Get()
        {
            List<CuentasBancaria> listaCuentas;
            using (var context = new BD_CRIPTOWALLETContext())
            {
                listaCuentas = context.CuentasBancarias.ToList();
            }

            return listaCuentas;
        }


        // GET api/<CuentasController>/5
        /// <summary>
        /// Recupera una cuenta bancaria según el ID pasado por parámetro.
        /// </summary>
        /// <param name="id">ID de Cuenta Bancaria</param>
        /// <returns>Cuenta Bancaria</returns>
        [Route("Id")]
        [HttpGet()]
        [Produces(typeof(CuentasBancaria))]
        public CuentasBancaria Get(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                try
                {
                    var cuentaBancariaSelect = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                    return cuentaBancariaSelect;
                }
                catch(Exception)
                {
                    throw;
                }                
            }

        }


        // POST api/<CuentasController>
        /// <summary>
        /// Creación y registro de una cuenta bancaria en la plataforma.
        /// </summary>
        /// <param name="cliente">Cliente al que se le crea una cuenta bancaria</param>
        /// <returns>Cuenta Bancaria</returns>
        [Route("byClient")]
        [HttpPost()]
        [Produces(typeof(CuentasBancaria))]
        public IEnumerable<CuentasBancaria> GetbyClient([FromBody] ClienteDTO cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.Where(cb => cb.IdCliente == cliente.IdCliente).ToList();
                return cuenta;
            }
        }

        // POST api/<CuentasController>
        /// <summary>
        /// Creación de cuenta bancaria
        /// </summary>
        /// <param name="cuentaDTO">Cuenta bancaria</param>
        [HttpPost]
        [Produces(typeof(CuentaDTO))]
        public void Post([FromBody] CuentaDTO cuentaDTO)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                context.CuentasBancarias.Add(new CuentasBancaria
                {
                    IdCliente = cuentaDTO.IdCliente,
                    Cbu = cuentaDTO.Cbu,
                    Alias = cuentaDTO.Alias,
                    Monto = cuentaDTO.Monto,
                    NumeroDeCuenta = cuentaDTO.NumeroDeCuenta,
                    Estado = cuentaDTO.Estado
                });

                context.SaveChanges();
            }
        }

        // PUT api/<CuentasController>/5
        /// <summary>
        /// Actualización de cuenta bancaria localizado por Número de Cuenta.
        /// </summary>
        /// <param name="nuevaCuenta">Nueva Cuenta Bancaria </param>
        [HttpPut("{numero}")]
        public void Put([FromBody] CuentaTransaccionDTO nuevaCuenta)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.NumeroDeCuenta == nuevaCuenta.NumeroDeCuenta);

                if (cuenta != null)
                {
                    cuenta.Monto = nuevaCuenta.Monto;
                    
                    context.Transacciones.Add(new Transaccione
                        {
                            CuentaDestino = nuevaCuenta.Transaccion.CuentaDestino,
                            CuentaOrigen = nuevaCuenta.Transaccion.CuentaOrigen,
                            FechaHoraTransaccion = DateTime.Now,
                            IdCuenta = nuevaCuenta.Transaccion.IdCuenta,
                            IdTipoMovimientos = nuevaCuenta.Transaccion.IdTipoMovimientos,
                            Monto = nuevaCuenta.Transaccion.Monto
                        });  
                     context.SaveChanges();
                 }                 
            }
        }

        // DELETE api/<CuentasController>/5
        /// <summary>
        /// Eliminación física de una cuenta localizado por ID.
        /// </summary>
        /// <param name="id">ID de Cuenta</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                if (cuenta != null)
                {
                    cuenta.Estado = false;
                }
               

            }


        }

    }
}
