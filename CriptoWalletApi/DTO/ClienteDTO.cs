namespace CriptoWalletApi.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Domicilio { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdLocalidad { get; set; }
        public bool Estado { get; set; }
    }
}
