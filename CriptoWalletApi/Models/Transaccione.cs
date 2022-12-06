using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Transaccione
    {
        public int IdTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
        public decimal Monto { get; set; }
        public string CuentaDestino { get; set; } = null!;
        public string CuentaOrigen { get; set; } = null!;
        public int IdCuenta { get; set; }
        public int IdTipoMovimientos { get; set; }

        public virtual CuentasBancaria IdCuentaNavigation { get; set; } = null!;
        public virtual TiposMovimiento IdTipoMovimientosNavigation { get; set; } = null!;
    }
}
