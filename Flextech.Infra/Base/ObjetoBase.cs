/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: ObjetoBase.cs
Espaço de nome...: Flextech.Infra.Base
Classe...........: ObjetoBase
Descrição........: Classe genérica para os objetos do sistema
==================================================================================
Criação..........: 15/12/2017 - Lessandro Santana
Alteração........: 18/01/2018 - Lessandro Santana
==================================================================================
*/

using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Flextech.Infra.Base
{
    [DataContract]
    public abstract class ObjetoBase : Flextech.Infra.Base.ObjetoObservavelBase
    {
        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public ObservableCollection<string> ColecaoDeErros { get { if (_ColecaoDeErros == null) this._ColecaoDeErros = new ObservableCollection<string>(); return this._ColecaoDeErros; } set { ColocarNoCampo(ref this._ColecaoDeErros, value); } }
        private ObservableCollection<string> _ColecaoDeErros;

        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public string TextoDaMensagemDeErro
        {
            get
            {
                this._TextoDaMensagemDeErro = "";
                foreach (string item in ColecaoDeErros)
                {
                    this._TextoDaMensagemDeErro += item;
                }

                return this._TextoDaMensagemDeErro;
            }
            private set { }
        }
        private string _TextoDaMensagemDeErro;

        [IgnoreDataMember]
        [XmlIgnoreAttribute]
        public bool ExisteErro { get { return this.ColecaoDeErros.Count > 0 ? true : false; } private set { } }
    }
}
