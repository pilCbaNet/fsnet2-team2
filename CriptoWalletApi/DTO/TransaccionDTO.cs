namespace CriptoWalletApi.DTO
{
    public class TransaccionDTO
    {
        /// <summary>
        /// Cantidad monetaria por la cual se realiza la transacción.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Representa al Número de cuenta destino de la transacción
        /// </summary>
        public string CuentaDestino { get; set; } = null!;

        /// <summary>
        /// Representa al Número de cuenta de origen de la transacción
        /// </summary>
        public string CuentaOrigen { get; set; } = null!;
        public int IdCuenta { get; set; }
        public int IdTipoMovimientos { get; set; }
    }
}
