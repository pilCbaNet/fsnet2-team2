using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class TiposCuentum
    {
        public TiposCuentum()
        {
            CuentasBancaria = new HashSet<CuentasBancaria>();
        }

        public int IdTipoCuenta { get; set; }
        public int IdMoneda { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual Moneda IdMonedaNavigation { get; set; } = null!;
        public virtual ICollection<CuentasBancaria> CuentasBancaria { get; set; }
    }
}
