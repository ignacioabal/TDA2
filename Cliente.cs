using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class Cliente
    {
        public string Nombre;
        public string Apellido;
        public string Dni;
        public string NroCliente;
        public CajaDeAhorro[] CajasDeAhorro;
        public CajaDeAhorro CajaDeAhorroPrimaria;

        public Cliente(string nombre, string apellido, string dni, string nroCliente, CajaDeAhorro[] cajasDeAhorros)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.NroCliente = nroCliente;
            this.CajasDeAhorro = cajasDeAhorros;

            this.CajaDeAhorroPrimaria = this.CajasDeAhorro[0];
        }

        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
        
    }
}
