using System;

namespace CriptoWalletApi.DTO
{
    public class TransaccionDTO
    {
        public int IdTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
        public decimal Monto { get; set; }
        public int CuentaDestino { get; set; }
        public int CuentaOrigen { get; set; }
        public int IdCuenta { get; set; }
        public int IdTipoMovimientos { get; set; }
    }
}
