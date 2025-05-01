using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        private decimal _tasaDeInteres;
        public void SetTasaDeInteres(decimal tasa) => _tasaDeInteres = tasa; //poner como campos
        public decimal GetTasaDeInteres() => _tasaDeInteres;

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares, decimal tasaDeInteres) : base(numero, saldo, titulares)
        {
            _tasaDeInteres = tasaDeInteres;
        }
        public override void Depositar(decimal monto)
        {
            //throw new NotImplementedException();
            _saldo += monto;
        }
        public override void Retirar(decimal monto)
        {
            //throw new NotImplementedException();
            _saldo -= +monto;
        }
        public override void AplicarInteres()
        {
            _saldo += _saldo * _tasaDeInteres;
        }

    }
}
