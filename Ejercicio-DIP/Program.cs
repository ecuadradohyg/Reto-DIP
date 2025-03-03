using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_DIP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Double valor = 0;
            ProcesadorPagos procesadorPagos = new ProcesadorPagos();
            Console.Write("Ingrese el valor a pagar: ");
            valor = Double.Parse(Console.ReadLine());
            procesadorPagos.procesar(valor);
            Console.ReadKey();
        }
    }
}
