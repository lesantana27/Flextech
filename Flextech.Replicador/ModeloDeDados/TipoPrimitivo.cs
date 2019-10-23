/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\TipoPrimitivo.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: TipoPrimitivo
Descrição........: Tipos primitivos de dados
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 11/01/2019 - Lessandro Santana
===============================================================================
*/

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{

    // ID   TYPE_NAME           TYPE_NAME_CSHARP    TYPE_NAME_SQL_SERVER    FIELD_LENGTH    FIELD_DECIMAL_PRECISION     DEFAULT_VALUE   FORMAT_DISPLAY          FORMAT_EDIT
    // 1	NONE                                                            -1	            -1			
    // 2	BINARY              Byte                binary		            50	            -1			
    // 3	BOOLEAN             bool                bit                     -1	            -1	                        FALSE		
    // 4	DATE                DateTime            date		            -1	            -1	                        NOW             dd/MM/yyyy              dd/MM/yyyy
    // 5	DATE_TIME           DateTime            datetime		        -1	            -1	                        NOW             dd/MM/yyyy HH:mm:ss     dd/MM/yyyy HH:mm:ss
    // 6	DATE_TIME_OFFSET    DateTimeOffset      datetimeoffset	        -1	            -1	                        00:00:00	    dd:hh:mm:ss:ffff        dd:hh:mm:ss:ffff
    // 7	DECIMAL             decimal             decimal		            12	            12	                        0	
    // 8	INTEGER             int                 int		                -1	            -1	                        0	
    // 9	MONEY               decimal             money                   12	            4	                        0	
    // 10	STRING              string              varchar                 50	            -1	                        EMPTY		    
    // 11	TIME                TimeSpan            time		            -1	            -1	                        00:00:00	    HH:mm:ss                HH:mm:ss
    // 12	UNIQUE_IDENTIFIER                       Guid                    -1	            -1	                        NEW_UID


    public enum TipoPrimitivoBase
    {
        Nenhum = 01,
        Binario = 02,
        Booleano = 03,
        Data = 04,
        DataHora = 05,
        DataHoraOffset = 06,
        Decimal = 07,
        Hora = 11,
        Identificador = 12,
        Inteiro = 08,
        Monetario = 09,
        Texto = 10,
    }

    [DataContract]
    public partial class TipoPrimitivo : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        const string NomeGrupo = "Nome";
        const string TipoGrupo = "Tipo";
        const string SistemaGrupo = "Sistema";





        [DataMember]
        [Category(NomeGrupo)]
        public string NomeDoTipo { get { return this._NomeDoTipo; } set { ColocarNoCampo(ref this._NomeDoTipo, value); } }
        private string _NomeDoTipo = "Não definido";

        [DataMember]
        [Category(NomeGrupo)]
        public string NomeDoTipoCSharp { get { return this._NomeDoTipoCSharp; } set { ColocarNoCampo(ref this._NomeDoTipoCSharp, value); } }
        private string _NomeDoTipoCSharp = "Não definido";

        [DataMember]
        [Category(NomeGrupo)]
        public string NomeDoTipoSqlServer { get { return this._NomeDoTipoSqlServer; } set { ColocarNoCampo(ref this._NomeDoTipoSqlServer, value); } }
        private string _NomeDoTipoSqlServer = "Não definido";





        [DataMember]
        [Category(TipoGrupo)]
        public int TamanhoDoCampo { get { return this._TamanhoDoCampo; } set { ColocarNoCampo(ref this._TamanhoDoCampo, value); } }
        private int _TamanhoDoCampo = -1;

        [DataMember]
        [Category(TipoGrupo)]
        public int PrecisaoDecimalDoCampo { get { return this._PrecisaoDecimalDoCampo; } set { ColocarNoCampo(ref this._PrecisaoDecimalDoCampo, value); } }
        private int _PrecisaoDecimalDoCampo = -1;





        [DataMember]
        [Category(SistemaGrupo)]
        public string ValorPadraoDoCampo { get { return this._ValorPadraoDoCampo; } set { ColocarNoCampo(ref this._ValorPadraoDoCampo, value); } }
        private string _ValorPadraoDoCampo = "Não definido";


        //TYPE_NAME_POSTGRE_SQL



        #region Construtor

        public TipoPrimitivo() : base()
        {
        }

        #endregion Construtor

        public void PreencherPropriedades(Flextech.Replicador.ModeloDeDados.TipoPrimitivo campo)
        {
            this.Identificador = campo.Identificador;

            this.NomeDoTipo = campo.NomeDoTipo;
            this.NomeDoTipoCSharp = campo.NomeDoTipoCSharp;
            this.NomeDoTipoSqlServer = campo.NomeDoTipoSqlServer;

            this.TamanhoDoCampo = campo.TamanhoDoCampo;
            this.PrecisaoDecimalDoCampo = campo.PrecisaoDecimalDoCampo;

            this.ValorPadraoDoCampo = campo.ValorPadraoDoCampo;
        }
    }
}