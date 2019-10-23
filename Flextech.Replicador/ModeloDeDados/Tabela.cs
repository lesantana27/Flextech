/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\Tabela.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: Tabela
Descrição........: Modelo de meta informação das tabelas do banco de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    public partial class Tabela : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        [DataMember]
        public string NomeDaTabela { get { return this._NomeDaTabela; } set { ColocarNoCampo(ref this._NomeDaTabela, value); } }
        private string _NomeDaTabela;

        [DataMember]
        public string PrefixoDoNomeDaTabela { get { return this._PrefixoDoNomeDaTabela; } set { ColocarNoCampo(ref this._PrefixoDoNomeDaTabela, value); } }
        private string _PrefixoDoNomeDaTabela = "";

        [DataMember]
        public string SufixoDoNomeDaTabela { get { return this._SufixoDoNomeDaTabela; } set { ColocarNoCampo(ref this._SufixoDoNomeDaTabela, value); } }
        private string _SufixoDoNomeDaTabela = "";
    }
}