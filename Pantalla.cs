using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class Pantalla
    {

        public class Login
        {
            public string[] MostrarInicio()
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero de tarjeta: ");
                string nroTarjetaIngresada = Console.ReadLine();

                Console.WriteLine("Ingrese la clave: ");
                string claveIngresada = Console.ReadLine();

                return new string[] { nroTarjetaIngresada, claveIngresada };
            }
            public void MostrarTarjetaInactiva(string nroTarjeta)
            {
                Console.Clear();
                Console.Write($"Intentos maximos alcanzados. La tarjeta numero {nroTarjeta} ha sido desactivada.");
                Console.ReadLine();
            }

            public void MostrarResultadoIngreso(bool usuarioIngresado, bool tarjetaActiva)
            {
                Console.Clear();

                if (!tarjetaActiva && usuarioIngresado)
                {
                    Console.WriteLine("La tarjeta se encuentra inactiva.");
                    Console.ReadLine();
                }
                else if (!usuarioIngresado)
                {
                    Console.WriteLine("Datos Incorrectos.");
                    Console.ReadLine();
                }
                else if (usuarioIngresado && tarjetaActiva)
                {
                    Console.WriteLine($"Ingreso Exitoso!");
                    Console.ReadLine();
                }
  

            }

        }



        public string MostrarMenuPrincipal(Cliente clienteIngresado)
        {
            Console.Clear();
            Console.WriteLine($"Bienvenido {clienteIngresado.NombreCompleto()}, ¿que desea hacer hoy?" +
                "\n0. Retirar Dinero" +
                "\n1. Transferir Dinero" +
                "\n2. Ver CBU" +
                "\n3. Cambiar Clave" +
                "\n4. Salir"
                );

            Console.WriteLine("Su elección: ");
            return Console.ReadLine();
        }



        public class Retiro
        {
            public void MostrarRetiro(CajaDeAhorro cajaDeAhorro)
            {
                Console.Clear();
                Console.WriteLine($"Cuanto desea retirar de la caja de ahorro {cajaDeAhorro.Moneda.Nombre} - {cajaDeAhorro.Nro}?(Fondos: {cajaDeAhorro.Balance} Descubierto: {cajaDeAhorro.Descubierto})");
                Console.WriteLine("Ingrese el monto (0 para cancelar): ");
            }

            public void MostrarFondosInsuficientes(CajaDeAhorro cajaDeAhorro)
            {

                Console.WriteLine($"Fondos insuficientes en caja de ahorro {cajaDeAhorro.Moneda.Nombre} - {cajaDeAhorro.Nro}. Ingrese un monto menor.");
            }

            public void MostrarRetiroExitoso()
            {
                Console.WriteLine("Retiro Exitoso! Su nuevo balance es: ");
            }
        }


        public void MostrarSeleccionCajaDeAhorro(CajaDeAhorro[] cajasDeAhorro)
        {
            Console.WriteLine("Elija la caja de ahorro a utilizar: ");

            int i = 0;
            for (i = 0; i < cajasDeAhorro.Length; i++)
            {
                Console.WriteLine($"{i}- {cajasDeAhorro[i].Moneda.Nombre} - {cajasDeAhorro[i].Nro} - {cajasDeAhorro[i].Balance}");

            }
            Console.WriteLine($"{i + 1}- Cancelar");

            Console.WriteLine("Su eleccion: ");
        }


        public void MostrarTransferencia()
        {

        }

        public void MostrarInformacionCbu()
        {

        }

        public void MostrarCambioDeClave()
        {

        }
    }


}
