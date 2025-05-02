using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Excepciones
{
    public class MontoNoValidoException : Exception
    {
        public MontoNoValidoException(string numeroCuenta) : base($"[{numeroCuenta}] - El monto ingresado no es válido para la operación solicitada.") { }

    }
    public class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estadoCuenta, string numeroCuenta) : base($"[{numeroCuenta}] - No se puede operar con la cuenta {estadoCuenta}.") { }
    }
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(string numeroCuenta) : base($"[{numeroCuenta}] - La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida. ") { }
    }
}
