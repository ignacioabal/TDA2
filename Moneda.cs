using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class Moneda
    {
        private string CodigoIso;
        public string Nombre;
        public float ValorRelativoAlArs;

        public Moneda(string nombre, float valorRelativoArs, string codIso)
        {
            this.Nombre = nombre;
            this.ValorRelativoAlArs = valorRelativoArs;
            this.CodigoIso = codIso;
        }
    }
}
