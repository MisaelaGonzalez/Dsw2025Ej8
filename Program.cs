using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Excepciones;
using System;
using System.Globalization;
using System.Threading;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main()
        {
            var cuentas = new List<CuentaBancaria>
            {
                new CajaDeAhorro("CA001", 1000m, new[] { "Misaela" }) { TasaDeInteres = 0.05m },
                new CajaDeAhorro("CA002", 500m, new[] { "Lara" }) { TasaDeInteres = 0.03m },
                new CuentaCorriente("CC001", 2000m, new[] { "Carlos" }) { Comision = 0.01m, LimiteDeDescubierto = 500m },
                new CuentaCorriente("CC002", 300m, new[] { "Martina" }) { Comision = 0.02m, LimiteDeDescubierto = 300m }
            };

            var acciones = new List<Action>
            {
                () => cuentas[0].Depositar(200),
                () => cuentas[1].Retirar(300),
                () => cuentas[2].Depositar(500),
                () => cuentas[3].Retirar(1000),
                () => cuentas[0].AplicarInteres(),
                () => cuentas[1].AplicarInteres(),
                () => cuentas[0].Retirar(-10)
            };

            foreach (var accion in acciones)
            {
                try
                {
                    accion();
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error inesperado] {ex.Message}");
                }
            }

            // Mostrar resumen usando clase anónima
            Console.WriteLine("\n------------------------ RESUMEN DE CUENTAS ----------------------\n");

            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado
                };

                Console.WriteLine($"Cuenta: {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: $ {resumen.Saldo} | Estado: {resumen.Estado}");
            }
        }
    }
}
