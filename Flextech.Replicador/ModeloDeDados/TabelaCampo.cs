/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\TabelaCampo.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: TabelaCampo
Descrição........: Modelo de meta informação dos campos das tabelas do banco de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/

using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    public partial class TabelaCampo : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        [DataMember]
        public Campo Campo { get { if (this._Campo == null) this._Campo = new Campo(); return this._Campo; } set { ColocarNoCampo(ref this._Campo, value); } }
        private Campo _Campo;

        [DataMember]
        public bool AceitarNulo { get { return this._AceitarNulo; } set { ColocarNoCampo(ref this._AceitarNulo, value); } }
        private bool _AceitarNulo = false;

        [DataMember]
        public int PosicaoDoCampoNaTabela { get { return this._PosicaoDoCampoNaTabela; } set { ColocarNoCampo(ref this._PosicaoDoCampoNaTabela, value); } }
        private int _PosicaoDoCampoNaTabela = -1;

        [DataMember]
        public int PosicaoDoCampoNaTela { get { return this._PosicaoDoCampoNaTela; } set { ColocarNoCampo(ref this._PosicaoDoCampoNaTela, value); } }
        private int _PosicaoDoCampoNaTela = -1;

        [DataMember]
        public bool ChavePrimaria { get { return this._ChavePrimaria; } set { ColocarNoCampo(ref this._ChavePrimaria, value); } }
        private bool _ChavePrimaria = false;

        [DataMember]
        public bool ChaveEstrangeira { get { return this._ChaveEstrangeira; } set { ColocarNoCampo(ref this._ChaveEstrangeira, value); } }
        private bool _ChaveEstrangeira = false;

        [DataMember]
        public Esquema ChaveEstrangeiraEsquema { get { if (this._ChaveEstrangeiraEsquema == null) this._ChaveEstrangeiraEsquema = new Esquema(); return this._ChaveEstrangeiraEsquema; } set { ColocarNoCampo(ref this._ChaveEstrangeiraEsquema, value); } }
        private Esquema _ChaveEstrangeiraEsquema;

        [DataMember]
        public Tabela ChaveEstrangeiraTabela { get { if (this._ChaveEstrangeiraTabela == null) this._ChaveEstrangeiraTabela = new Tabela(); return this._ChaveEstrangeiraTabela; } set { ColocarNoCampo(ref this._ChaveEstrangeiraTabela, value); } }
        private Tabela _ChaveEstrangeiraTabela;

        [DataMember]
        public TabelaCampo ChaveEstrangeiraCampo { get { if (this._ChaveEstrangeiraCampo == null) this._ChaveEstrangeiraCampo = new TabelaCampo(); return this._ChaveEstrangeiraCampo; } set { ColocarNoCampo(ref this._ChaveEstrangeiraCampo, value); } }
        private TabelaCampo _ChaveEstrangeiraCampo;


        #region Propriedades comuns entre a classe Campo e a classe TabelaCampo

        [DataMember]
        public string ValorPadraoDoCampo { get { return this._ValorPadraoDoCampo; } set { ColocarNoCampo(ref this._ValorPadraoDoCampo, value); } }
        private string _ValorPadraoDoCampo = "Não definido";

        [DataMember]
        public bool UsarValorPadraoDoCampo { get { return this._UsarValorPadraoDoCampo; } set { ColocarNoCampo(ref this._UsarValorPadraoDoCampo, value); } }
        private bool _UsarValorPadraoDoCampo = false;

        [DataMember]
        public bool CampoCalculadoPeloSistema { get { return this._CampoCalculadoPeloSistema; } set { ColocarNoCampo(ref this._CampoCalculadoPeloSistema, value); } }
        private bool _CampoCalculadoPeloSistema = false;

        [DataMember]
        public string FormatoParaMostrar { get { return this._FormatoParaMostrar; } set { ColocarNoCampo(ref this._FormatoParaMostrar, value); } }
        private string _FormatoParaMostrar = "Não definido";

        [DataMember]
        public string FormatoParaEditar { get { return this._FormatoParaEditar; } set { ColocarNoCampo(ref this._FormatoParaEditar, value); } }
        private string _FormatoParaEditar = "Não definido";

        [DataMember]
        public string RotuloNormal { get { return this._RotuloNormal; } set { ColocarNoCampo(ref this._RotuloNormal, value); } }
        private string _RotuloNormal = "Não definido";

        [DataMember]
        public string PrefixoDoRotulo { get { return this._PrefixoDoRotulo; } set { ColocarNoCampo(ref this._PrefixoDoRotulo, value); } }
        private string _PrefixoDoRotulo = "";

        [DataMember]
        public string SufixoDoRotulo { get { return this._SufixoDoRotulo; } set { ColocarNoCampo(ref this._SufixoDoRotulo, value); } }
        private string _SufixoDoRotulo = "";

        [DataMember]
        public string RotuloCurto { get { return this._RotuloCurto; } set { ColocarNoCampo(ref this._RotuloCurto, value); } }
        private string _RotuloCurto = "";

        [DataMember]
        public string RotuloCompleto { get { return this._RotuloCompleto; } set { ColocarNoCampo(ref this._RotuloCompleto, value); } }
        private string _RotuloCompleto = "";

        [DataMember]
        public string RotuloGrid { get { return this._RotuloGrid; } set { ColocarNoCampo(ref this._RotuloGrid, value); } }
        private string _RotuloGrid = "";

        [DataMember]
        public string RotuloFiltro { get { return this._RotuloFiltro; } set { ColocarNoCampo(ref this._RotuloFiltro, value); } }
        private string _RotuloFiltro = "";

        [DataMember]
        public bool VisivelNaTela { get { return this._VisivelNaTela; } set { ColocarNoCampo(ref this._VisivelNaTela, value); } }
        private bool _VisivelNaTela = true;

        #endregion Propriedades comuns entre a classe Campo e a classe TabelaCampo
    }
}

