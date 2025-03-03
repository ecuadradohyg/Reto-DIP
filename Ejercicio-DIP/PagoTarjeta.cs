using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_DIP
{
    public class PagoTarjeta
    {
        public void pagar(Double valor)
        {
            Console.WriteLine($"Se efectuó el pago de ${valor} usando tarjeta de crédito");
        }
    }
}
