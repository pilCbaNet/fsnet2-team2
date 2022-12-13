using CriptoWalletApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860






/*

       

        // POST api/<CuentasController>
        [HttpPost]
        public void Post([FromBody] CuentaDTO cuentaDTO)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                context.CuentasBancarias.Add(new CuentasBancaria
                {
                    IdCliente = cuentaDTO.IdCliente,
                    Cbu=cuentaDTO.Cbu,
                    Alias=cuentaDTO.Alias,
                    Monto=cuentaDTO.Monto,
                    NumeroDeCuenta=cuentaDTO.NumeroDeCuenta,
                    Estado = cuentaDTO.Estado
                });

                context.SaveChanges();
            }
        }

        // PUT api/<CuentasController>/5
        [HttpPut("{numero}")]
        public void Put([FromBody] CuentaDTO nuevaCuenta)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.FirstOrDefault(cb => cb.NumeroDeCuenta == nuevaCuenta.NumeroDeCuenta);

                if (cuenta != null)
                { 
                    cuenta.Monto = nuevaCuenta.Monto;
                    context.SaveChanges();
                }
                else
                {

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
                else
                {

                }
                
            }
        }
    }
}

 */











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
        [Route("Id")]
        [HttpGet()]
        public CuentasBancaria Get(int id)
        {
                using (var context = new BD_CRIPTOWALLETContext())
                {
                    var cuentaBancariaSelect = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                    return cuentaBancariaSelect;
                }

        }

        /*
          [Route("byClient")]
        [HttpPost]
        public IEnumerable<CuentasBancaria> GetbyClient([FromBody]ClienteDTO cliente)
        {
            using (var context = new BD_CRIPTOWALLETContext())
            {
                var cuenta = context.CuentasBancarias.Where(cb => cb.IdCliente == cliente.IdCliente).ToList();
                return cuenta;
            }
        }
         */

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

        

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
