/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: SqlServer.cs
Espaço de nome...: Flextech.Infra.ConexaoDeDados
Classe...........: SqlServer
Descrição........: Classe de Conexão com o SQL Server
==================================================================================
Criação..........: 15/12/2017 - Lessandro Santana
Alteração........: 26/04/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flextech.Infra.ConexaoDeDados
{
    public class SqlServer : Flextech.Infra.Base.ObjetoBase
    {

        #region Propriedades

        public Flextech.Infra.Registrador.RegistradorBasico RegistradorBasico { get { if (this._RegistradorBasico == null) this._RegistradorBasico = new Flextech.Infra.Registrador.RegistradorBasico(); return this._RegistradorBasico; } private set { ColocarNoCampo(ref this._RegistradorBasico, value); } }
        private Flextech.Infra.Registrador.RegistradorBasico _RegistradorBasico;

        public SqlConnectionStringBuilder StringDeConexao { get { if (this._StringDeConexao == null) this._StringDeConexao = new SqlConnectionStringBuilder(); return this._StringDeConexao; } private set { ColocarNoCampo(ref this._StringDeConexao, value); } }
        private SqlConnectionStringBuilder _StringDeConexao;

        public SqlCommand ComandoSql { get { if (this._ComandoSql == null) this._ComandoSql = new SqlCommand(); return this._ComandoSql; } set { ColocarNoCampo(ref this._ComandoSql, value); } }
        private SqlCommand _ComandoSql;

        public string ConsultaSql { get { return this._ConsultaSql; } set { ColocarNoCampo(ref this._ConsultaSql, value); } }
        private string _ConsultaSql;

        public string NomeDaClasse { get { return this._NomeDaClasse; } set { ColocarNoCampo(ref this._NomeDaClasse, value); } }
        private string _NomeDaClasse;

        public string NomeDoMetodo { get { return this._NomeDoMetodo; } set { ColocarNoCampo(ref this._NomeDoMetodo, value); } }
        private string _NomeDoMetodo;

        #endregion Propriedades

        #region Construtor

        public SqlServer(string stringDeConexao)
        {
            this.StringDeConexao.ConnectionString = stringDeConexao;
        }

        public SqlServer(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            this.StringDeConexao = sqlConnectionStringBuilder;
        }

        public SqlServer(string dataSource, string initialCatalog, string userID, string password, bool integratedSecurity, bool persistSecurityInfo)
        {
            this.StringDeConexao.DataSource = dataSource;
            this.StringDeConexao.InitialCatalog = initialCatalog;
            this.StringDeConexao.UserID = userID;
            this.StringDeConexao.Password = password;
            if (persistSecurityInfo) this.StringDeConexao.PersistSecurityInfo = persistSecurityInfo;
            if (integratedSecurity) this.StringDeConexao.IntegratedSecurity = integratedSecurity;
        }

        #endregion Construtor

        #region Métodos Privados

        private Dictionary<string, string> ObterParametrosSql()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string value;

            foreach (SqlParameter sqlParameterItem in ComandoSql.Parameters)
            {
                value = sqlParameterItem.Value == null ? "" : sqlParameterItem.Value.ToString();
                dic.Add(sqlParameterItem.ParameterName, value);
            }

            return dic;
        }

        #endregion Métodos Privados

        #region Métodos Públicos


        public void AdicionarParametro(string nomeDoParametro, object valorDoParametro)
        {
            ComandoSql.Parameters.Add(new SqlParameter() { ParameterName = nomeDoParametro, Value = valorDoParametro });
        }

        public void AdicionarParametro(string nomeDoParametro, object valorDoParametro, SqlDbType tipoDeDadoSql)
        {
            ComandoSql.Parameters.Add(new SqlParameter() { ParameterName = nomeDoParametro, Value = valorDoParametro, SqlDbType = tipoDeDadoSql });
        }

        public void AdicionarParametro(string nomeDoParametro, object valorDoParametro, SqlDbType tipoDeDadoSql, int tamanhoDoCampoNoSql, ParameterDirection direcaoDoParametro)
        {
            ComandoSql.Parameters.Add(new SqlParameter() { ParameterName = nomeDoParametro, Value = valorDoParametro, SqlDbType = tipoDeDadoSql, Size = tamanhoDoCampoNoSql, Direction = direcaoDoParametro });
        }

        public void ExecutarComando(System.Data.CommandType tipoDoComando, string comandoSql)
        {
            ConsultaSql = comandoSql;
            ExecutarConsulta(tipoDoComando: tipoDoComando, comRetornoDeDados: false);
        }

        public DataTable ExecutarConsulta(System.Data.CommandType tipoDoComando, bool comRetornoDeDados)
        {
            DataTable dt;
            base.ColecaoDeErros.Clear();

            try
            {
                using (SqlConnection conexaoSql = new SqlConnection(StringDeConexao.ConnectionString))
                {
                    ComandoSql.CommandText = ConsultaSql;
                    ComandoSql.CommandType = tipoDoComando;
                    ComandoSql.CommandTimeout = 300;
                    ComandoSql.Connection = conexaoSql;

                    conexaoSql.Open();

                    if (comRetornoDeDados)
                    {
                        dt = new DataTable("Tabela01");
                        dt.Load(ComandoSql.ExecuteReader());
                        return dt;
                    }
                    else
                    {
                        ComandoSql.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException exSql)
            {
                ColecaoDeErros.Add("ERRO SQL: " + exSql.Message);
                RegistradorBasico.RegistrarExcecaoDeBancoDeDados(NomeDaClasse, NomeDoMetodo, ConsultaSql, ObterParametrosSql(), exSql);
            }
            catch (Exception ex)
            {
                ColecaoDeErros.Add("ERRO GERAL: " + ex.Message);
                RegistradorBasico.RegistrarExcecaoDeBancoDeDados(NomeDaClasse, NomeDoMetodo, ConsultaSql, ObterParametrosSql(), ex);
            }

            return null;
        }

        #endregion Métodos Públicos
    }
}
