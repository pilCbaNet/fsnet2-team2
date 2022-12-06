using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class TiposMovimiento
    {
        public TiposMovimiento()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int IdTipoMovimiento { get; set; }
        public string NombreTipoMovimiento { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
