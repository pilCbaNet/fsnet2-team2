using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdDomicilio { get; set; }
        public int IdLocalidad { get; set; }
        public string Calle { get; set; } = null!;
        public int Numero { get; set; }
        public string? Departamento { get; set; }
        public int? Piso { get; set; }
        public string Barrio { get; set; } = null!;

        public virtual Localidade IdLocalidadNavigation { get; set; } = null!;
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
