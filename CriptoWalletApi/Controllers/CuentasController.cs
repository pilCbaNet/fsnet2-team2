using CriptoWalletApi.DTO;
using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;

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
                listaCuentas= context.CuentasBancarias.ToList();
            }

            return listaCuentas;
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public CuentasBancaria Get(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                return cuenta;
            }
        }

        // POST api/<CuentasController>
        [HttpPost]
        public void Post([FromBody] CuentaDTO cuentaDTO)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                context.CuentasBancarias.Add(new CuentasBancaria
                {
                    IdCliente = cuentaDTO.Id_cliente,
                    Cbu=cuentaDTO.Cbu,
                    Alias=cuentaDTO.Alias,
                    Monto=cuentaDTO.Monto,
                    NumeroDeCuenta=cuentaDTO.Numero_de_cuenta,
                    Estado = cuentaDTO.Estado
                });

                context.SaveChanges();
            }
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CuentaDTO nuevaCuenta)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                cuenta.Monto = nuevaCuenta.Monto;

                context.SaveChanges();
            }
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                cuenta.Estado = false;
            }
        }
    }
}
