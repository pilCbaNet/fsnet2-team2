using CriptoWalletApi.Models;

namespace CriptoWalletApi.DTO
{
    public class CuentaTransaccionDTO
    {
        public int IdCliente { get; set; }
        public int Cbu { get; set; }
        public string Alias { get; set; }
        public int Monto { get; set; }
        public int NumeroDeCuenta { get; set; }
        public bool Estado { get; set; }
        public TransaccionDTO Transaccion { get; set; }
    }
}
