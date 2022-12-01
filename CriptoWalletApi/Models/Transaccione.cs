using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Transaccione
    {
        public Transaccione()
        {
            CuentasBancaria = new HashSet<CuentasBancaria>();
        }

        public int IdTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
        public decimal Monto { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int CuentaDestino { get; set; }
        public int? CuentaOrigen { get; set; }

        public virtual TiposMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
        public virtual ICollection<CuentasBancaria> CuentasBancaria { get; set; }
    }
}
