using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
