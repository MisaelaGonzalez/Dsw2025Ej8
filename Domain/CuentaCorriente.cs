using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        private decimal _limiteDeDescubierto;
        private decimal _comision;

        public void SetComision(decimal comision) => _comision = comision;
        public decimal GetComision() => _comision;

        public void SetLimiteDeDescubierto(decimal limite) => _limiteDeDescubierto = limite;
        public decimal GetLimiteDeDescubierto() => _limiteDeDescubierto;

        public CuentaCorriente(string numero, decimal saldo, string[] titulares, decimal limiteDeDescubierto, decimal comision) : base(numero, saldo, titulares)
        {
            _limiteDeDescubierto = limiteDeDescubierto;
            _comision = comision;
        }
        public override void Depositar(decimal monto)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
        public override void Retirar(decimal monto)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }

        public override void AplicarInteres(){}
    }
}
