namespace CriptoWalletApi.DTO
{
    public class TransaccionDTO
    {
        /// <summary>
        /// Cantidad monetaria por la cual se realiza la transacción.
        /// </summary>
        public decimal Monto { get; set; }
        public string CuentaDestino { get; set; } = null!;
        public string CuentaOrigen { get; set; } = null!;
        public int IdCuenta { get; set; }
        public int IdTipoMovimientos { get; set; }
    }
}
