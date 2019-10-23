/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra.Web
Arquivo..........: Interfaces\IControllerBase.cs
Espaço de nome...: Flextech.Infra.Web.Interfaces
Classe...........: IControlerBase
Descrição........: Interface para a base do controller de todos os projetos web
===============================================================================
Criação..........: 22/03/2018 - Lessandro Santana
Alteração........: 23/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Web.Interfaces
{
    public interface IControllerBase
    {
        Flextech.Infra.Web.Classes.Enderecos Enderecos { get; set; }

        Flextech.Infra.Web.Classes.Parametros Parametros { get; set; }

        Flextech.Infra.Web.Classes.VariaveisDoServidor VariaveisDoServidor { get; set; }

        string NomeDoComputador { get; }

        string EnderecoIP { get; }

        string NomeDoUsuario { get; set; }

        void AnalisarParametros();

        void AnalizarVariaveisDoServidor();

        void AutenticarUsuario(string email, string senha);

        void AutenticarUsuario(string tokenAutenticacao);

        void ValidarChamada();

        void Navegar(string enderecoDaPaginaDeDestino = "");

        void PreencherObjetoComDadosDoForm<T>(ref T objeto);

    }
}