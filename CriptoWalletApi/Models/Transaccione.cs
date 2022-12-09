﻿using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Transaccione
    {
        public int IdTransaccion { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
        public decimal Monto { get; set; }
        public int CuentaDestino { get; set; }
        public int CuentaOrigen { get; set; }
        public int IdCuenta { get; set; }
        public int IdTipoMovimientos { get; set; }

        public virtual CuentasBancaria IdCuentaNavigation { get; set; } = null!;
        public virtual TiposMovimiento IdTipoMovimientosNavigation { get; set; } = null!;
    }
}
