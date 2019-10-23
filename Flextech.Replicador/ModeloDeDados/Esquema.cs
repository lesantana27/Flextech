/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\Esquema.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: Esquema
Descrição........: Modelo de meta informação dos esquemas do banco de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    public partial class Esquema : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        [DataMember]
        public string NomeDoEsquema { get { return this._NomeDoEsquema; } set { ColocarNoCampo(ref this._NomeDoEsquema, value); } }
        private string _NomeDoEsquema;
    }
}