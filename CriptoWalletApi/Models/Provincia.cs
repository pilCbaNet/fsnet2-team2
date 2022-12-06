using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Localidades = new HashSet<Localidade>();
        }

        public int IdProvincia { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Localidade> Localidades { get; set; }
    }
}
