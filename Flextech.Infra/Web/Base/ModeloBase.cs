/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Web\Base\ModeloBase.cs
Espaço de nome...: Flextech.Infra.Web.Base
Classe...........: ModeloBase
Descrição........: Classe base para implementação do modelo em Web MVC
===============================================================================
Criação..........: 27/05/2019 - Lessandro Santana
Alteração........: 27/05/2019 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Web.Base
{
    public partial class ModeloBase : Flextech.Infra.Base.ObjetoBase
    {

        #region Propriedades

        public string NomeComputador { get { return this._NomeComputador; } private set { ColocarNoCampo(ref this._NomeComputador, value); } }
        private string _NomeComputador;

        public string NomeUsuario { get { return this._NomeUsuario; } private set { ColocarNoCampo(ref this._NomeUsuario, value); } }
        private string _NomeUsuario;

        public string EnderecoIP { get { return this._EnderecoIP; } private set { ColocarNoCampo(ref this._EnderecoIP, value); } }
        private string _EnderecoIP;

        #endregion Propriedades

        public ModeloBase(string nomeComputador, string nomeUsuario, string enderecoIP)
        {
            this.NomeComputador = nomeComputador;
            this.NomeUsuario = nomeUsuario;
            this.EnderecoIP = enderecoIP;
        }
    }
}