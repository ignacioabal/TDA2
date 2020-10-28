using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class CajeroAutomatico
    {
        static private Pantalla pantalla;
        static private BaseDeDatosCajero baseDeDatos;
        static private TarjetaDeDebito tarjetaIngresada;
        static private bool usuarioIngresado;

        static void Main(string[] args)
        {
            IniciarDatos();

            IniciarCajero();

            InicioDeSesion();

            MenuPrincipal();

        }

        static private void IniciarCajero()
        {
            pantalla = new Pantalla();

        }

        static private void IniciarDatos()
        {
            Moneda ARS = new Moneda("ARS", 1.0F, "032");
            Moneda USD = new Moneda("USD", 86.0F, "840");
            Moneda EUR = new Moneda("EUR", 95.0F, "978");


            CajaDeAhorro[] cajasDeAhorro_Juan = new CajaDeAhorro[] { new CajaDeAhorro("01","123456789","PEREZ.JUAN.UNO",ARS,22000f,33500f),
                                                                new CajaDeAhorro("02","124567894","PEREZ.JUAN.USD",USD,100f,900f),
                                                                new CajaDeAhorro("03","543463462","PEREZ.JUAN.EUR",EUR,10f,50f)
                                                                };

            CajaDeAhorro[] cajasDeAhorro_Pablo = new CajaDeAhorro[] { new CajaDeAhorro("01","123456789","PEREZ.JUAN.UNO",ARS,22000f,33500f),
                                                                new CajaDeAhorro("02","124567894","PEREZ.JUAN.USD",USD,100f,900f),
                                                                new CajaDeAhorro("03","543463462","PEREZ.JUAN.EUR",EUR,10f,50f)
                                                                };

            Cliente cliente_Juan = new Cliente("Juan", "Perez", "25.044.304", "001", cajasDeAhorro_Juan);

            Cliente cliente_Pablo = new Cliente("Pablo", "Gonzales", "27.534.314", "002", cajasDeAhorro_Pablo);


            TarjetaDeDebito[] tarjetasEnSistema = { new TarjetaDeDebito(cliente_Juan,"123456",new DateTime(2026,07,01),true,"1234"),
                                                    new TarjetaDeDebito(cliente_Pablo,"111444",new DateTime(2028,02,01),false,"1748")};


            baseDeDatos = new BaseDeDatosCajero(tarjetasEnSistema, 100500f);
        }

        static private bool DatosValidos(string[] input)
        {
            return int.TryParse(input[0], out int output) || int.TryParse(input[1], out output);
        }

        static private void InicioDeSesion()
        {
            Pantalla.Login pantallaLogin = new Pantalla.Login();

            int intentosErroneos = 0;

            while (!usuarioIngresado)
            {

                string[] datosDeLogin = pantallaLogin.MostrarInicio();

                string nroTarjeta = datosDeLogin[0];
                string claveTarjeta = datosDeLogin[1];
                TarjetaDeDebito tarjeta = null;
                bool tarjetaActiva = true;

                if (DatosValidos(datosDeLogin))
                {

                    tarjeta = baseDeDatos.BuscarTarjetaDeDebito(nroTarjeta);

                    if (tarjeta != null)
                    {
                        tarjetaActiva = tarjeta.activa;
                    }
                }

                if (!tarjetaActiva)
                {

                }

                if (tarjetaActiva && baseDeDatos.ValidarTarjetaIngresada(tarjeta,claveTarjeta))
                {
                    usuarioIngresado = true;
                    tarjetaIngresada = tarjeta;
                }
                else
                {
                    intentosErroneos++;
                }

                if (intentosErroneos == 3)
                {
                    baseDeDatos.DesactivarTarjeta(nroTarjeta);
                    pantallaLogin.MostrarTarjetaInactiva(nroTarjeta);
                    intentosErroneos = 0;
                }
                else
                {
                    pantallaLogin.MostrarResultadoIngreso(usuarioIngresado, tarjetaActiva);
                }
            }


        }

        static private void MenuPrincipal()
        {
            string input = pantalla.MostrarMenuPrincipal(tarjetaIngresada.cliente);

            if (int.TryParse(input, out int eleccion))
            {
                switch (eleccion)
                {
                    case 0:
                        RetirarDinero();
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }

                MenuPrincipal();
                return;
            }
        }

        static CajaDeAhorro SeleccionarCajaDeAhorro()
        {
            int input = -1;
            while (input < 0 || input > tarjetaIngresada.cliente.CajasDeAhorro.Length)
            {
                pantalla.MostrarSeleccionCajaDeAhorro(tarjetaIngresada.cliente.CajasDeAhorro);
                int.TryParse(Console.ReadLine(), out input);
            }

            if (input == tarjetaIngresada.cliente.CajasDeAhorro.Length)
            {
                return null;
            }


            return tarjetaIngresada.cliente.CajasDeAhorro[input];

        }

        static void RetirarDinero()
        {
            Pantalla.Retiro pantallaRetiro = new Pantalla.Retiro();
            CajaDeAhorro cajaDeAhorro = SeleccionarCajaDeAhorro();

            if (cajaDeAhorro == null)
            {
                MenuPrincipal();
                return;
            }


            pantallaRetiro.MostrarRetiro(cajaDeAhorro);
            float.TryParse(Console.ReadLine(), out float montoARetirar);

            while (baseDeDatos.DescontarDineroCajaDeAhorro(tarjetaIngresada.cliente, cajaDeAhorro, montoARetirar))
            {
                if (montoARetirar == 0)
                {
                    MenuPrincipal();
                    return;
                }
                pantallaRetiro.MostrarFondosInsuficientes(cajaDeAhorro);
                float.TryParse(Console.ReadLine(), out montoARetirar);
            }




        }


    }
}
