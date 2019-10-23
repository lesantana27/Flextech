/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra.Web
Arquivo..........: Classes\Enderecos.cs
Espaço de nome...: Flextech.Infra.Web.Classes
Classe...........: Enderecos
Descrição........: Endereços dos sistemas da FLEXTECH
===============================================================================
Criação..........: 23/03/2018 - Lessandro Santana
Alteração........: 26/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Web.Classes
{
    public partial class Enderecos
    {
        private bool _AmbienteDeProducao = false;

        private string _EnderecoBaseDesenvolvimento = @"http://localhost/";
        private string _EnderecoBaseProducao = @"https://www.flextech.com.br/";

        #region Propriedades

        public bool AmbienteDeProducao { get { return this._AmbienteDeProducao; } }

        public string Autenticacao { get { return ObterEndereco(); } }
        public string Controle { get { return ObterEndereco(); } }
        public string Engenharia { get { return ObterEndereco(); } }

        #endregion Propriedades

        public Enderecos()
        {
            this._AmbienteDeProducao = (Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("Ambiente.De.Producao").ToUpper() == "SIM");
            this._EnderecoBaseDesenvolvimento = Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("Endereco.Base");
        }

        private string ObterEndereco([CallerMemberName] string nomeDaPropriedade = "")
        {
            if (AmbienteDeProducao) return $"{this._EnderecoBaseProducao}{nomeDaPropriedade}/";

            return $"{this._EnderecoBaseDesenvolvimento}Web.{nomeDaPropriedade}/";
        }

    }
}