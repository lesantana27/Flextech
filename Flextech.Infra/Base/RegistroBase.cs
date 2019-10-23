/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: RegistroBase.cs
Espaço de nome...: Flextech.Infra.Base
Classe...........: RegistroBase
Descrição........: Classe base de registro para mapear objetos de banco. POCO / DTO
==================================================================================
Criação..........: 29/12/2017 - Lessandro Santana
Alteração........: 17/09/2019 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Flextech.Infra.Base
{
    [DataContract]
    public abstract class RegistroBase : Flextech.Infra.Base.ObjetoBase
    {
        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public int ID_NOVO_REGISTRO { get; set; }

        public virtual int ID { get; set; }

        public abstract void MarcarRegistrosCarregadosDoBancoDeDados();

        public abstract bool ExistemCamposEditados();

        public abstract void InicializarPropriedadesComValoresPadrao(bool marcarRegistroCarregadoDoBanco = true);

        public abstract Dictionary<string, object> ObterDicionarioDePropriedades();

        //public abstract T_TABELA NovoRegistroDaTabela();
    }
}
