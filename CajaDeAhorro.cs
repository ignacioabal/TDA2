using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{


    class CajaDeAhorro
    {
        public string Nro;
        public string Cbu;
        public string Alias;
        public Moneda Moneda;
        public float Descubierto;
        public float Balance;

        public CajaDeAhorro(string nro, string cbu, string alias, Moneda moneda, float descubierto,float balance)
        {
            this.Nro = nro;
            this.Cbu = cbu;
            this.Alias = alias;
            this.Moneda = moneda;
            this.Descubierto = descubierto;
            this.Balance = balance;
        }



    }
}
