using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_DIP
{
    public class ProcesadorPagos
    {
        PagoTarjeta pagoTarjeta = new PagoTarjeta();
        public void procesar(Double valor)
        {
            pagoTarjeta.pagar(valor);
        }
    }
}
