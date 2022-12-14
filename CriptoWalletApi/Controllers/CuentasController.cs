using CriptoWalletApi.DTO;
using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace CriptoWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {

        // GET: api/<CuentasController>
        [HttpGet]
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
        [Route("Id")]
        [HttpPost()]
        public CuentasBancaria Post([FromBody] CuentaIdDTO cuentaId)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                try
                {
                    var cuentaBancariaSelect = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == cuentaId.IdCuenta);
                    return cuentaBancariaSelect;
                }
                catch(Exception)
                {
                    throw;
                }                
            }

        }


        // POST api/<CuentasController>
        [Route("byClient")]
        [HttpPost()]
        public IEnumerable<CuentasBancaria> GetbyClient([FromBody] ClienteDTO cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.Where(cb => cb.IdCliente == cliente.IdCliente).ToList();
                return cuenta;
            }
        }

        // POST api/<CuentasController>
        [Route("Cuenta")]
        [HttpPost]
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
