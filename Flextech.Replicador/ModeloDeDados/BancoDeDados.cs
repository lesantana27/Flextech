/*
===============================================================================
Solução..........: Flextech
Projeto..........: NOME_DO_PROJETO
Arquivo..........: DIRETORIO\BancoDeDados.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: BancoDeDados
Descrição........: Modelo de meta informação do banco de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    public partial class BancoDeDados : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        [DataMember]
        public string NomeDoBancoDeDados { get { return this._NomeDoBancoDeDados; } set { ColocarNoCampo(ref this._NomeDoBancoDeDados, value); } }
        private string _NomeDoBancoDeDados = "Não definido";
    }
}