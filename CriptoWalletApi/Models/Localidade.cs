using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Localidade
    {
        public Localidade()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdLocalidad { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
