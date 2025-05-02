using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto {  get; init; }
        public decimal Comision {  get; init; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }
        public override void Depositar(decimal _monto)
        {
            EstadoDeCuenta(Estado);
            ValidarMonto(_monto);
            _monto -= _monto * Comision;
            Saldo += _monto;
        }
        public override void Retirar(decimal _monto)
        {
            EstadoDeCuenta(Estado);
            ValidarMonto(_monto);
	    if (Saldo - _monto >= -LimiteDeDescubierto)
            {
                Saldo -= _monto;
            }else
            {
                Estado = Estado.Suspendida;
		throw new SaldoInsuficienteException(Numero);
            }
        }

        public override void AplicarInteres(){}
    }
}
