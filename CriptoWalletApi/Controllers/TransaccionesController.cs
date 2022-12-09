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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransaccionesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //[Route("cuentaId")]
        //[HttpGet]
        //public Transaccione GetHistorialTransacciones(int cuentaId)
        //{

        //}



        // POST api/<TransaccionesController>
        [HttpPost]
        public void Post([FromBody]
        int IdTransaccion,
        DateTime FechaHoraTransaccion,
        decimal Monto,
        int CuentaDestino,
        int CuentaOrigen,
        int IdCuenta,
        int IdTipoMovimientos)

        {
            try
            {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    Transaccione transaccion = new Transaccione
                    {
                        IdTransaccion = IdTransaccion,
                        FechaHoraTransaccion = FechaHoraTransaccion,
                        Monto = Monto,
                        CuentaDestino = CuentaDestino,
                        CuentaOrigen = CuentaOrigen,
                        IdCuenta = IdCuenta,
                        IdTipoMovimientos = IdTipoMovimientos,
                    };

                    CuentasBancaria cuentaDescuento = context.CuentasBancarias.Where(t => t.IdCuenta == CuentaOrigen).FirstOrDefault();
                    cuentaDescuento.Monto = cuentaDescuento.Monto - Monto;
                    context.Update(cuentaDescuento);

                    CuentasBancaria cuentaAdicion = context.CuentasBancarias.Where(t => t.IdCuenta == CuentaDestino).FirstOrDefault();
                    cuentaAdicion.Monto = cuentaAdicion.Monto + Monto;
                    context.Update(cuentaAdicion);

                    context.Transacciones.Add(transaccion);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
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
