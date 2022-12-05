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
                    CuentasBancaria? cuentaBancariaSelect = context.CuentasBancarias.FirstOrDefault(cb => cb.IdCuenta == id);
                    return cuentaBancariaSelect;
                }

        }



        // POST api/<CuentasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
