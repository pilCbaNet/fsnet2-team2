using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class CuentasBancaria
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTransaccion { get; set; }
        public int IdTipoCuenta { get; set; }
        public int Cbu { get; set; }
        public string Alias { get; set; } = null!;
        public long Monto { get; set; }
        public int NumeroDeCuenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual TiposCuentum IdTipoCuentaNavigation { get; set; } = null!;
        public virtual Transaccione IdTransaccionNavigation { get; set; } = null!;
    }
}
