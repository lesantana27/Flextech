/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Utilitarios\Computador.cs
Espaço de nome...: Flextech.Infra.Utilitarios
Classe...........: Computador
Descrição........: 
===============================================================================
Criação..........: 27/05/2019 - Lessandro Santana
Alteração........: 27/05/2019 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Utilitarios
{
    public partial class Computador
    {
        // USAR no HTML: @Flextech.Infra.Utilitarios.DeterminarNomeDoComputadorPeloIP(Request.UserHostAddress)
        public static string DeterminarNomeDoComputadorPeloIP(string IP)
        {
            IPAddress meuIP = IPAddress.Parse(IP);
            IPHostEntry ipHostEntry = Dns.GetHostEntry(meuIP);
            List<string> listaDeNomes = ipHostEntry.HostName.ToString().Split('.').ToList();
            return listaDeNomes.First();
        }
    }
}