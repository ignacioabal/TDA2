using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TDA2
{
    class BaseDeDatosCajero
    {
        public TarjetaDeDebito[] Tarjetas;
        public float FondosEnArs;

        public BaseDeDatosCajero(TarjetaDeDebito[] tarjetas, float fondos)
        {
            this.Tarjetas = tarjetas;
            this.FondosEnArs = fondos;
        }

        public bool ValidarTarjetaIngresada(TarjetaDeDebito tarjeta, string claveTarjetaIngresada)
        {
 
            if (tarjeta.clave == claveTarjetaIngresada) return true;

            return false;
        }

        public bool TarjetaEstaActiva(string numTarjetaIngresado)
        {
            return BuscarTarjetaDeDebito(numTarjetaIngresado).activa;
        }

        public bool TarjetaExiste(string numTarjetaIngresado)
        {
            if(BuscarTarjetaDeDebito(numTarjetaIngresado) != null)
            {
                return true;
            }

            return false;
        }

        public void DesactivarTarjeta(string numTarjetaIngresado)
        {
            foreach (TarjetaDeDebito tarjeta in Tarjetas)
            {
                if (tarjeta.numero == numTarjetaIngresado)
                {
                    tarjeta.activa = false;
                }
            }
        }

        public bool DescontarDineroCajaDeAhorro(Cliente cliente, CajaDeAhorro cajaIngresada, float monto)
        {
            CajaDeAhorro cajaDeAhorro = BuscarCajaDeAhorro(cliente, cajaIngresada);

            if(monto > cajaDeAhorro.Balance + cajaDeAhorro.Descubierto || monto == 0)
            {
                return false;
            }

            if(monto > cajaDeAhorro.Balance)
            {
                cajaDeAhorro.Descubierto -= (monto - cajaDeAhorro.Balance);
                return true;
            }
            else
            {
                cajaDeAhorro.Balance -= monto;
                return true;
            }

        }

        public CajaDeAhorro BuscarCajaDeAhorro(Cliente cliente, CajaDeAhorro cajaIngresada)
        {
            foreach (TarjetaDeDebito tarjeta in Tarjetas)
            {
                if (tarjeta.cliente == cliente)
                {
                    foreach (CajaDeAhorro cajaDeAhorro in tarjeta.cliente.CajasDeAhorro)
                    {
                        if (cajaDeAhorro.Alias == cajaIngresada.Alias)
                        {
                            return cajaDeAhorro;
                        }
                    }

                }
            }
            return null;
        }
    
        public TarjetaDeDebito BuscarTarjetaDeDebito(string numeroDeTarjetaIngresado)
        {
            foreach (TarjetaDeDebito tarjeta in Tarjetas)
            {
                if (tarjeta.numero == numeroDeTarjetaIngresado)
                {
                    return tarjeta;
                }
            }

            return null;
        }
    
    }
}
