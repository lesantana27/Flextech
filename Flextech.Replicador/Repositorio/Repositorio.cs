/*
===============================================================================
Solução..........: Flextech
Projeto..........: NOME_DO_PROJETO
Arquivo..........: DIRETORIO\Repositorio.cs
Espaço de nome...: Flextech.Replicador.Repositorio
Classe...........: Repositorio
Descrição........: 
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Flextech.Replicador.Repositorio
{
    [DataContract]
    public partial class Repositorio : Flextech.Replicador.Base.RepositorioBase
    {
        #region Propriedades de controle

        [XmlIgnoreAttribute]
        public string CaminhoCompletoDoArquivo { get { return this._CaminhoCompletoDoArquivo; } set { ColocarNoCampo(ref this._CaminhoCompletoDoArquivo, value); } }
        private string _CaminhoCompletoDoArquivo = @"C:\";

        [XmlIgnoreAttribute]
        public string NomeDoArquivo { get { return this._NomeDoArquivo; } set { ColocarNoCampo(ref this._NomeDoArquivo, value); } }
        private string _NomeDoArquivo;

        [XmlIgnoreAttribute]
        public bool SalvarPendente { get { return this._SalvarPendente; } set { ColocarNoCampo(ref this._SalvarPendente, value); } }
        private bool _SalvarPendente = false;

        #endregion Propriedades de controle

        [DataMember]
        public ModeloDeDados.BancoDeDados BancoDeDados { get { if (this._BancoDeDados == null) this._BancoDeDados = new ModeloDeDados.BancoDeDados(); return this._BancoDeDados; } set { ColocarNoCampo(ref this._BancoDeDados, value); } }
        private ModeloDeDados.BancoDeDados _BancoDeDados;

        [DataMember]
        public ObservableCollection<EsquemaRepositorio> ColecaoDeEsquemas { get { if (this._ColecaoDeEsquemas == null) this._ColecaoDeEsquemas = new ObservableCollection<EsquemaRepositorio>(); return this._ColecaoDeEsquemas; } set { ColocarNoCampo(ref this._ColecaoDeEsquemas, value); } }
        private ObservableCollection<EsquemaRepositorio> _ColecaoDeEsquemas;

        [DataMember]
        public ObservableCollection<ModeloDeDados.Campo> ColecaoDeCamposUnicos { get { if (this._ColecaoDeCamposUnicos == null) this._ColecaoDeCamposUnicos = new ObservableCollection<ModeloDeDados.Campo>(); return this._ColecaoDeCamposUnicos; } set { ColocarNoCampo(ref this._ColecaoDeCamposUnicos, value); } }
        private ObservableCollection<ModeloDeDados.Campo> _ColecaoDeCamposUnicos;

        [DataContract]
        public partial class EsquemaRepositorio : Flextech.Replicador.Base.RepositorioBase
        {
            [DataMember]
            public ModeloDeDados.Esquema Esquema { get { if (this._Esquema == null) this._Esquema = new ModeloDeDados.Esquema(); return this._Esquema; } set { ColocarNoCampo(ref this._Esquema, value); } }
            private ModeloDeDados.Esquema _Esquema;

            [DataMember]
            public ObservableCollection<TabelaRepositorio> ColecaoDeTabelas { get { if (this._ColecaoDeTabelas == null) this._ColecaoDeTabelas = new ObservableCollection<TabelaRepositorio>(); return this._ColecaoDeTabelas; } set { ColocarNoCampo(ref this._ColecaoDeTabelas, value); } }
            private ObservableCollection<TabelaRepositorio> _ColecaoDeTabelas;

            [DataContract]
            public partial class TabelaRepositorio : Flextech.Replicador.Base.RepositorioBase
            {
                [DataMember]
                public ModeloDeDados.Tabela Tabela { get { if (this._Tabela == null) this._Tabela = new ModeloDeDados.Tabela(); return this._Tabela; } set { ColocarNoCampo(ref this._Tabela, value); } }
                private ModeloDeDados.Tabela _Tabela;

                [DataMember]
                public ObservableCollection<ModeloDeDados.TabelaCampo> ColecaoDeCampos { get { if (this._ColecaoDeCampos == null) this._ColecaoDeCampos = new ObservableCollection<ModeloDeDados.TabelaCampo>(); return this._ColecaoDeCampos; } set { ColocarNoCampo(ref this._ColecaoDeCampos, value); } }
                private ObservableCollection<ModeloDeDados.TabelaCampo> _ColecaoDeCampos;
            }
        }

        public void NovoArquivo()
        {
            this.BancoDeDados = new ModeloDeDados.BancoDeDados();
            this.ColecaoDeCamposUnicos = new ObservableCollection<ModeloDeDados.Campo>();
            this.ColecaoDeEsquemas = new ObservableCollection<EsquemaRepositorio>();

            this.NomeDoArquivo = "";
            this.SalvarPendente = false;
        }

        public void CarregarArquivo()
        {
            Flextech.Infra.Utilitarios.SerializadorXml serializadorXml = new Flextech.Infra.Utilitarios.SerializadorXml();
            Flextech.Replicador.Repositorio.Repositorio repositorio;
            string mensagemDeRetorno = "";

            base.ColecaoDeErros.Clear();

            serializadorXml.DesserializarDoArquivo<Flextech.Replicador.Repositorio.Repositorio>(arquivoCaminhoCompleto: this.CaminhoCompletoDoArquivo, objeto: out repositorio, mensagemDeRetorno: out mensagemDeRetorno);
            if (string.IsNullOrEmpty(mensagemDeRetorno) == false)
            {
                base.ColecaoDeErros.Add(mensagemDeRetorno);
                return;
            }

            this.SalvarPendente = false;
            this.BancoDeDados = repositorio.BancoDeDados;
            this.ColecaoDeCamposUnicos = repositorio.ColecaoDeCamposUnicos;
            this.ColecaoDeEsquemas = repositorio.ColecaoDeEsquemas;
        }

        public void SalvarArquivo()
        {
            Flextech.Infra.Utilitarios.SerializadorXml serializadorXml = new Flextech.Infra.Utilitarios.SerializadorXml();
            string mensagemDeRetorno = "";

            base.ColecaoDeErros.Clear();

            serializadorXml.SerializarParaArquivo(objeto: this, arquivoCaminhoCompleto: this.CaminhoCompletoDoArquivo, mensagemDeRetorno: out mensagemDeRetorno);

            if (string.IsNullOrEmpty(mensagemDeRetorno) == false)
                base.ColecaoDeErros.Add(mensagemDeRetorno);
        }

    }
}