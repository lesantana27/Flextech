using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Teste.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Flextech.Replicador.Repositorio.Repositorio repositorio = new Replicador.Repositorio.Repositorio();

            repositorio.SalvarArquivo();

            System.Console.WriteLine("FIM");
            System.Console.ReadLine();
        }
    }
}
