using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class TarjetaDeDebito
    {


        public Cliente cliente;
        public string numero;
        public DateTime FechaDeVencimiento;
        public bool activa;
        public string clave;

        public TarjetaDeDebito(Cliente cliente, string num, DateTime fechaDeVencimiento, bool activa, string clave)
        {
            this.cliente = cliente;
            this.numero = num;
            this.FechaDeVencimiento = fechaDeVencimiento;
            this.activa = activa;
            this.clave = clave;
        }

        public TarjetaDeDebito() { }

    }
}
