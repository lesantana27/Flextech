/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra.Web
Arquivo..........: Classes\Parametros.cs
Espaço de nome...: Flextech.Infra.Web.Classes
Classe...........: Parametros
Descrição........: 
===============================================================================
Criação..........: 13/03/2018 - Lessandro Santana
Alteração........: 26/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Web.Classes
{
    public partial class Parametros : Flextech.Infra.Base.ObjetoBase
    {
        /// <summary>
        /// fut = FLEX_ID.USUARIO.TOKEN
        /// </summary>
        public string fut { get; set; }

        /// <summary>
        /// fuat = FLEX_ID.USUARIO_AUTENTICACAO.TOKEN
        /// </summary>
        public string fuat { get; set; }

        /// <summary>
        /// pnr = Endereço da página de retorno depois que eu autenticar
        /// </summary>
        public string pnr { get; set; }

        public Parametros()
        {
            InicializarProriedades();
        }

        private void InicializarProriedades()
        {
            this.fut = string.Empty;
            this.fuat = string.Empty;
            this.pnr = string.Empty;
        }

        public void PopularParametros(Dictionary<string, string> dic)
        {
            if (dic["fut"] != null) this.fut = dic["fut"];
            if (dic["fuat"] != null) this.fuat = dic["fuat"];

            if (dic["pnr"] != null) this.pnr = dic["pnr"];
        }

        public string ObterParametros()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"?p=");

            sb.Append($"fut={fut};");
            sb.Append($"fuat={fuat};");

            //sb.Append($"pnr={pnr};");

            return sb.ToString();
        }

    }
}