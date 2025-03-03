using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_DIP
{
    public class PagoCripto
    {
        public void pagar(Double valor)
        {
            Console.WriteLine($"Se realizó el pago con {valor} criptomonedas");
        }
    }
}
