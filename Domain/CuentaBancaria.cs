using Dsw2025Ej8.Excepciones;
namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }

    public abstract void Depositar(decimal _monto);

    public abstract void Retirar(decimal _monto);
    public abstract void AplicarInteres();

    protected void ValidarMonto(decimal _monto)
    {
        if (_monto <= 0) throw new MontoNoValidoException(Numero);
    }
    protected void EstadoDeCuenta(Estado estadoCuenta)
    {
        if (Estado.Activa != estadoCuenta) throw new CuentaNoActivaException(estadoCuenta, Numero);
    }

}
