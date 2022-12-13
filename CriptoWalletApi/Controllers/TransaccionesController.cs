using CriptoWalletApi.DTO;
using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CriptoWalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
            // GET: api/<TransaccionesController>
        [HttpGet]
        public IEnumerable<Transaccione> Get()
        {
            List<Transaccione> listaTransaccione;
            using (var context = new BD_CRIPTOWALLETContext())
            {
                listaTransaccione = context.Transacciones.ToList();
            }

            return listaTransaccione;
        }

        // GET api/<TransaccionesController>/5
        [Route("Id")]
        [HttpGet]
        public Transaccione Get(int id)
        {
            try
            {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    Transaccione? transaccioneSelect = context.Transacciones.FirstOrDefault(t => t.IdTransaccion == id);
                    return transaccioneSelect;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        // POST api/<TransaccionesController>
        [HttpPost]
        public void Post([FromBody] TransaccionDTO tr)
        {
            using(var context = new BD_CRIPTOWALLETContext())
            {
                context.Transacciones.Add(new Transaccione
                {
                    CuentaDestino= tr.CuentaDestino,
                    CuentaOrigen= tr.CuentaOrigen,
                    FechaHoraTransaccion= DateTime.Now,
                    IdCuenta= tr.IdCuenta,
                    IdTipoMovimientos = tr.IdTipoMovimientos,
                    Monto = tr.Monto,

                });
                context.SaveChanges();
            }
        }

        // PUT api/<TransaccionesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransaccionesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
