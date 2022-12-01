using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            TiposCuenta = new HashSet<TiposCuentum>();
        }

        public int IdMoneda { get; set; }
        public string NombreMoneda { get; set; } = null!;
        public string Simbolo { get; set; } = null!;

        public virtual ICollection<TiposCuentum> TiposCuenta { get; set; }
    }
}
