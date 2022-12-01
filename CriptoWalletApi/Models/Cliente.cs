using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CuentasBancaria = new HashSet<CuentasBancaria>();
        }

        public int IdCliente { get; set; }
        public int IdDomicilio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int IdUsuario { get; set; }

        public virtual Domicilio IdDomicilioNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<CuentasBancaria> CuentasBancaria { get; set; }
    }
}
