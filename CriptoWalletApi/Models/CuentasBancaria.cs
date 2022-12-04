using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class CuentasBancaria
    {
        public CuentasBancaria()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int Cbu { get; set; }
        public string Alias { get; set; } = null!;
        public long Monto { get; set; }
        public int NumeroDeCuenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
