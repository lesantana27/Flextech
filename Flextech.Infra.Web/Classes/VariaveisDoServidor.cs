/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra.Web
Arquivo..........: Classes\VariaveisDoServidor.cs
Espaço de nome...: Flextech.Infra.Web.Classes
Classe...........: VariaveisDoServidor
Descrição........: 
===============================================================================
Criação..........: 13/03/2018 - Lessandro Santana
Alteração........: 13/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Web.Classes
{
    public partial class VariaveisDoServidor : Flextech.Infra.Base.ObjetoBase
    {
        public string HTTP_USER_AGENT { get { return this._HTTP_USER_AGENT; } set { ColocarNoCampo(ref this._HTTP_USER_AGENT, value); } }
        private string _HTTP_USER_AGENT = "";

        public string REMOTE_ADDR { get { return this._REMOTE_ADDR; } set { ColocarNoCampo(ref this._REMOTE_ADDR, value); } }
        private string _REMOTE_ADDR = "";


        public string REMOTE_HOST { get { return this._REMOTE_HOST; } set { ColocarNoCampo(ref this._REMOTE_HOST, value); } }
        private string _REMOTE_HOST = "";
    }
}