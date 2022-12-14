using System;
using System.Collections.Generic;

namespace CriptoWalletApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CuentasBancaria = new HashSet<CuentasBancaria>();
        }
        /// <summary>
        /// Id identficativo del cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Domicilio que incluye Calle, numero, piso
        /// </summary>
        public string Domicilio { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdLocalidad { get; set; }
        /// <summary>
        /// Estado del Cliente representa si está habilitado o deshabilitado.
        /// </summary>
        public bool Estado { get; set; }

        public virtual Localidade IdLocalidadNavigation { get; set; } = null!;
        public virtual ICollection<CuentasBancaria> CuentasBancaria { get; set; }
    }
}
