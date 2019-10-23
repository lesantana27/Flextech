/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: Base\ModeloDeDadosBase.cs
Espaço de nome...: Flextech.Replicador.Base
Classe...........: ModeloDeDadosBase
Descrição........: Classe base para o modelo de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Flextech.Replicador.Base
{
    [DataContract]
    public partial class ModeloDeDadosBase : Flextech.Infra.Base.ObjetoObservavelBase
    {

        [Display(GroupName = "ID")]
        [DataMember]
        public Guid Identificador { get { return this._Identificador; } set { ColocarNoCampo(ref this._Identificador, value); } }
        private Guid _Identificador = Guid.NewGuid();


        // Adicionar estes campos

        //DEVELOPER_DOCUMENTATION
        //DEVELOPER_HELP_LINK
        //DEVELOPER_HELP_TEXT
        //DEVELOPER_HELP_TITLE
        //TOOLTIP
        //USER_DOCUMENTATION
        //USER_HELP_LINK
        //USER_HELP_TEXT
        //USER_HELP_TITLE
    }
}