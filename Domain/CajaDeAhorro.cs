using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; }

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }
        public override void Depositar(decimal _monto)
        {
            EstadoDeCuenta(Estado);
            ValidarMonto(_monto);
            Saldo += _monto;
        }
        public override void Retirar(decimal _monto)
        {
            EstadoDeCuenta(Estado);
            ValidarMonto(_monto);
            SaldoDeCuenta(_monto);
        }
        public override void AplicarInteres()
        {
            if (TasaDeInteres <= 0) throw new InvalidOperationException("La tasa de interes debe ser mayor que 0");

            Saldo += Saldo * TasaDeInteres;
        }
        public void SaldoDeCuenta(decimal _monto)
        {
            if (Saldo - _monto < 0)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException(Numero);
            }
            else
            {
                Saldo -= +_monto;
            }
        }

    }
}
