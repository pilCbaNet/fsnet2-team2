namespace CriptoWalletApi.DTO
{
    public class CuentaDTO
    {
        public int Id_cliente { get; set; }
        public int Cbu { get; set; }
        public string Alias { get; set; }
        public int Monto { get; set; }
        public int NumeroDeCuenta { get; set; }
        public bool Estado { get; set; }
    }
}
