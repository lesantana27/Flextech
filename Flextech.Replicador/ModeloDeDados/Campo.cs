/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\Campo.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: Campo
Descrição........: Modelo de meta informação dos campos
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 10/01/2019 - Lessandro Santana
===============================================================================
*/

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    [DataContract]
    public partial class Campo : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        const string TipoGrupo = "Tipo";
        const string NomeGrupo = "Nome";
        const string NomeBancoDeDadosGrupo = "Banco de Dados";
        const string SistemaGrupo = "Sistema";
        const string TelaGrupo = "Mostrar na tela";
        const string RotuloGrupo = "Rótulos (labels)";





        //[DataMember]
        //[Category(TipoGrupo)]
        //public TipoPrimitivo TipoPrimitivo { get { if (this._TipoPrimitivo == null) this._TipoPrimitivo = new TipoPrimitivo(); return this._TipoPrimitivo; } set { ColocarNoCampo(ref this._TipoPrimitivo, value); } }
        //private TipoPrimitivo _TipoPrimitivo;

        [DataMember]
        [Category(TipoGrupo)]
        public TipoPrimitivoBase TipoPrimitivo { get { return this._TipoPrimitivo; } set { ColocarNoCampo(ref this._TipoPrimitivo, value); } }
        private TipoPrimitivoBase _TipoPrimitivo = TipoPrimitivoBase.Nenhum;

        [DataMember]
        [Category(TipoGrupo)]
        public int TamanhoDoCampo { get { return this._TamanhoDoCampo; } set { ColocarNoCampo(ref this._TamanhoDoCampo, value); } }
        private int _TamanhoDoCampo = -1;

        [DataMember]
        [Category(TipoGrupo)]
        public int PrecisaoDecimalDoCampo { get { return this._PrecisaoDecimalDoCampo; } set { ColocarNoCampo(ref this._PrecisaoDecimalDoCampo, value); } }
        private int _PrecisaoDecimalDoCampo = -1;





        [DataMember]
        [Category(NomeGrupo)]
        public string NomeDoCampo { get { return this._NomeDoCampo; } set { ColocarNoCampo(ref this._NomeDoCampo, value); } }
        private string _NomeDoCampo = "";

        [DataMember]
        [Category(NomeGrupo)]
        public string PrefixoDoNomeDoCampo { get { return this._PrefixoDoNomeDoCampo; } set { ColocarNoCampo(ref this._PrefixoDoNomeDoCampo, value); } }
        private string _PrefixoDoNomeDoCampo = "";

        [DataMember]
        [Category(NomeGrupo)]
        public string SufixoDoNomeDoCampo { get { return this._SufixoDoNomeDoCampo; } set { ColocarNoCampo(ref this._SufixoDoNomeDoCampo, value); } }
        private string _SufixoDoNomeDoCampo = "";





        [DataMember]
        [Category(NomeBancoDeDadosGrupo)]
        public string NomeDoCampoNoBancoDeDados { get { return this._NomeDoCampoNoBancoDeDados; } set { ColocarNoCampo(ref this._NomeDoCampoNoBancoDeDados, value); } }
        private string _NomeDoCampoNoBancoDeDados = "";

        [DataMember]
        [Category(NomeBancoDeDadosGrupo)]
        public string PrefixoDoNomeDoCampoNoBancoDeDados { get { return this._PrefixoDoNomeDoCampoNoBancoDeDados; } set { ColocarNoCampo(ref this._PrefixoDoNomeDoCampoNoBancoDeDados, value); } }
        private string _PrefixoDoNomeDoCampoNoBancoDeDados = "";

        [DataMember]
        [Category(NomeBancoDeDadosGrupo)]
        public string SufixoDoNomeDoCampoNoBancoDeDados { get { return this._SufixoDoNomeDoCampoNoBancoDeDados; } set { ColocarNoCampo(ref this._SufixoDoNomeDoCampoNoBancoDeDados, value); } }
        private string _SufixoDoNomeDoCampoNoBancoDeDados = "";

        
        
        
        
        #region Propriedades comuns entre a classe Campo e a classe TabelaCampo

        [DataMember]
        [Category(SistemaGrupo)]
        public string ValorPadraoDoCampo { get { return this._ValorPadraoDoCampo; } set { ColocarNoCampo(ref this._ValorPadraoDoCampo, value); } }
        private string _ValorPadraoDoCampo = "";

        [DataMember]
        [Category(SistemaGrupo)]
        public bool UsarValorPadraoDoCampo { get { return this._UsarValorPadraoDoCampo; } set { ColocarNoCampo(ref this._UsarValorPadraoDoCampo, value); } }
        private bool _UsarValorPadraoDoCampo = false;

        [DataMember]
        [Category(SistemaGrupo)]
        public bool CampoCalculadoPeloSistema { get { return this._CampoCalculadoPeloSistema; } set { ColocarNoCampo(ref this._CampoCalculadoPeloSistema, value); } }
        private bool _CampoCalculadoPeloSistema = false;





        [DataMember]
        [Category(TelaGrupo)]
        public string FormatoParaMostrar { get { return this._FormatoParaMostrar; } set { ColocarNoCampo(ref this._FormatoParaMostrar, value); } }
        private string _FormatoParaMostrar = "";

        [DataMember]
        [Category(TelaGrupo)]
        public string FormatoParaEditar { get { return this._FormatoParaEditar; } set { ColocarNoCampo(ref this._FormatoParaEditar, value); } }
        private string _FormatoParaEditar = "";

        [DataMember]
        [Category(TelaGrupo)]
        public bool VisivelNaTela { get { return this._VisivelNaTela; } set { ColocarNoCampo(ref this._VisivelNaTela, value); } }
        private bool _VisivelNaTela = true;





        [DataMember]
        [Category(RotuloGrupo)]
        public string RotuloNormal { get { return this._RotuloNormal; } set { ColocarNoCampo(ref this._RotuloNormal, value); } }
        private string _RotuloNormal = "Não definido";

        [DataMember]
        [Category(RotuloGrupo)]
        public string PrefixoDoRotulo { get { return this._PrefixoDoRotulo; } set { ColocarNoCampo(ref this._PrefixoDoRotulo, value); } }
        private string _PrefixoDoRotulo = "";

        [DataMember]
        [Category(RotuloGrupo)]
        public string SufixoDoRotulo { get { return this._SufixoDoRotulo; } set { ColocarNoCampo(ref this._SufixoDoRotulo, value); } }
        private string _SufixoDoRotulo = "";

        [DataMember]
        [Category(RotuloGrupo)]
        public string RotuloCurto { get { return this._RotuloCurto; } set { ColocarNoCampo(ref this._RotuloCurto, value); } }
        private string _RotuloCurto = "";

        [DataMember]
        [Category(RotuloGrupo)]
        public string RotuloCompleto { get { return this._RotuloCompleto; } set { ColocarNoCampo(ref this._RotuloCompleto, value); } }
        private string _RotuloCompleto = "";

        [DataMember]
        [Category(RotuloGrupo)]
        public string RotuloGrid { get { return this._RotuloGrid; } set { ColocarNoCampo(ref this._RotuloGrid, value); } }
        private string _RotuloGrid = "";

        [DataMember]
        [Category(RotuloGrupo)]
        public string RotuloFiltro { get { return this._RotuloFiltro; } set { ColocarNoCampo(ref this._RotuloFiltro, value); } }
        private string _RotuloFiltro = "";

        #endregion Propriedades comuns entre a classe Campo e a classe TabelaCampo


        #region Construtor

        public Campo() : base()
        {
            NomeDoCampo = $"Campo NOVO - {base.Identificador.ToString()}";
        }

        #endregion Construtor

        public void PreencherPropriedades(Flextech.Replicador.ModeloDeDados.Campo campo)
        {
            this.Identificador = campo.Identificador;

            this.TipoPrimitivo = campo.TipoPrimitivo;
            this.TamanhoDoCampo = campo.TamanhoDoCampo;
            this.PrecisaoDecimalDoCampo = campo.PrecisaoDecimalDoCampo;

            this.NomeDoCampo = campo.NomeDoCampo.Trim();
            this.PrefixoDoNomeDoCampo = campo.PrefixoDoNomeDoCampo.Trim();
            this.SufixoDoNomeDoCampo = campo.SufixoDoNomeDoCampo.Trim();

            this.NomeDoCampoNoBancoDeDados = campo.NomeDoCampoNoBancoDeDados.Trim();
            this.PrefixoDoNomeDoCampoNoBancoDeDados = campo.PrefixoDoNomeDoCampoNoBancoDeDados.Trim();
            this.SufixoDoNomeDoCampoNoBancoDeDados = campo.SufixoDoNomeDoCampoNoBancoDeDados.Trim();

            this.ValorPadraoDoCampo = campo.ValorPadraoDoCampo.Trim();
            this.UsarValorPadraoDoCampo = campo.UsarValorPadraoDoCampo;
            this.CampoCalculadoPeloSistema = campo.CampoCalculadoPeloSistema;

            this.FormatoParaMostrar = campo.FormatoParaMostrar.Trim();
            this.FormatoParaEditar = campo.FormatoParaEditar.Trim();
            this.VisivelNaTela = campo.VisivelNaTela;

            this.RotuloNormal = campo.RotuloNormal.Trim();
            this.PrefixoDoRotulo = campo.PrefixoDoRotulo.Trim();
            this.SufixoDoRotulo = campo.SufixoDoRotulo.Trim();
            this.RotuloCurto = campo.RotuloCurto.Trim();
            this.RotuloCompleto = campo.RotuloCompleto.Trim();
            this.RotuloGrid = campo.RotuloGrid.Trim();
            this.RotuloFiltro = campo.RotuloFiltro.Trim();
        }


    }
}

