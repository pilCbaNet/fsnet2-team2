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
        /// <summary>
        /// Clave Bancaria Única o Clave Bancaria Unificada, utilizado por los bancos para la identificación de las cuentas bancarias, formado por 22 números.
        /// </summary>
        public int Cbu { get; set; }
        /// <summary>
        /// Código entre 6 y 20 caracteres que admite letras, números, guión medio y punto para identificar una cuenta bancaria.
        /// </summary>
        public string Alias { get; set; } = null!;
        /// <summary>
        /// Saldo de la cuenta bancaria.
        /// </summary>
        public long Monto { get; set; }
        /// <summary>
        /// El código de cuenta bancaria, consta de 20 dígitos.
        /// </summary>
        public int NumeroDeCuenta { get; set; }
        /// <summary>
        /// Estado de la Cuenta Bancaria representa si está habilitado o deshabilitado.
        /// </summary>
        public bool Estado { get; set; }



        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
