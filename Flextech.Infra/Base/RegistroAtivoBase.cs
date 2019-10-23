/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: RegistroAtivoBase.cs
Espaço de nome...: Flextech.Infra.Base
Classe...........: RegistroAtivoBase
Descrição........: Classe base para implementação do padrão Registro Ativo
==================================================================================
Criação..........: 11/01/2018 - Lessandro Santana
Alteração........: 19/09/2019 - Lessandro Santana
==================================================================================
*/

using Flextech.Infra.Extensoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace Flextech.Infra.Base
{
    public abstract class RegistroAtivoBase<T_TABELA, T_VISUALIZACAO> : Flextech.Infra.Base.ObjetoBase
        where T_TABELA : RegistroBase, new()
        where T_VISUALIZACAO : T_TABELA, new()
    {
        private const string NomeDaClasse = "Flextech.Infra.Base.RegistroAtivoBase";

        #region Propriedades

        public abstract string NomeDoEsquema { get; set; }

        public abstract string NomeDaTabela { get; set; }

        private string ProcedimentoArmazenadoPrefixo { get; set; } = @"zusp__";
        private string ProcedimentoArmazenadoExcluirPorID { get; set; } = @"__excluir_por_id";
        private string ProcedimentoArmazenadoSalvar { get; set; } = @"__salvar";
        private string ProcedimentoArmazenadoSelecionar { get; set; } = @"__selecionar";



        public T_TABELA RegistroDaTabela { get { if (this._RegistroDaTabela == null) this._RegistroDaTabela = new T_TABELA(); return this._RegistroDaTabela; } set { ColocarNoCampo(ref this._RegistroDaTabela, value); } }
        private T_TABELA _RegistroDaTabela;

        public ObservableCollection<T_TABELA> ColecaoDeRegistroDaTabela { get { if (this._ColecaoDeRegistroDaTabela == null) this._ColecaoDeRegistroDaTabela = new ObservableCollection<T_TABELA>(); return this._ColecaoDeRegistroDaTabela; } set { ColocarNoCampo(ref this._ColecaoDeRegistroDaTabela, value); } }
        private ObservableCollection<T_TABELA> _ColecaoDeRegistroDaTabela;

        public T_VISUALIZACAO RegistroDaVisualizacao { get { if (this._RegistroDaVisualizacao == null) this._RegistroDaVisualizacao = new T_VISUALIZACAO(); return this._RegistroDaVisualizacao; } set { ColocarNoCampo(ref this._RegistroDaVisualizacao, value); } }
        private T_VISUALIZACAO _RegistroDaVisualizacao;

        public ObservableCollection<T_VISUALIZACAO> ColecaoDeRegistroDaVisualizacao { get { if (this._ColecaoDeRegistroDaVisualizacao == null) this._ColecaoDeRegistroDaVisualizacao = new ObservableCollection<T_VISUALIZACAO>(); return this._ColecaoDeRegistroDaVisualizacao; } set { ColocarNoCampo(ref this._ColecaoDeRegistroDaVisualizacao, value); } }
        private ObservableCollection<T_VISUALIZACAO> _ColecaoDeRegistroDaVisualizacao;

        public Dictionary<string, object> Parametros { get { if (this._Parametros == null) this._Parametros = new Dictionary<string, object>(); return this._Parametros; } set { ColocarNoCampo(ref this._Parametros, value); } }
        private Dictionary<string, object> _Parametros;

        //public string NomeComputador { get { return this._NomeComputador; } private set { ColocarNoCampo(ref this._NomeComputador, value); } }
        //private string _NomeComputador;

        //public string NomeUsuario { get { return this._NomeUsuario; } private set { ColocarNoCampo(ref this._NomeUsuario, value); } }
        //private string _NomeUsuario;

        //public string EnderecoIP { get { return this._EnderecoIP; } private set { ColocarNoCampo(ref this._EnderecoIP, value); } }
        //private string _EnderecoIP;

        #endregion Propriedades

        protected Flextech.Infra.ConexaoDeDados.SqlServer ObterConexaoSqlServer()
        {
            Flextech.Infra.Estatico.BaseDeDados.SqlServer.LerConfiguracaoDoAppConfigOuWebConfig();

            return new Flextech.Infra.ConexaoDeDados.SqlServer(
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.DataSource,
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.InitialCatalog,
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.UserID,
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.Password,
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.IntegratedSecurity,
                    Flextech.Infra.Estatico.BaseDeDados.SqlServer.PersistSecurityInfo);
        }

        public RegistroAtivoBase(string nomeComputador, string nomeUsuario, string enderecoIP)
        {
            //this.NomeComputador = nomeComputador;
            //this.NomeUsuario = nomeUsuario;
            //this.EnderecoIP = enderecoIP;

            Flextech.Infra.Estatico.Sistema.NomeComputador = nomeComputador;
            Flextech.Infra.Estatico.Sistema.NomeUsuario = nomeUsuario;
            Flextech.Infra.Estatico.Sistema.EnderecoIP = enderecoIP;
        }

        #region Excluir

        public void ExcluirDaTabela(int id)
        {
            Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();

            conexao.NomeDaClasse = NomeDaClasse;
            conexao.NomeDoMetodo = $"ExcluirDaTabela(id: {id}); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
            conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}{ProcedimentoArmazenadoExcluirPorID}";

            conexao.AdicionarParametro("ID", id);

            conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: false);

            base.ColecaoDeErros = conexao.ColecaoDeErros;
        }

        #endregion Excluir

        #region Selecionar

        //public ObservableCollection<T_TABELA> SelecionarDaTabela(Dictionary<string, object> parametros)
        //{
        //    Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();
        //    DataTable dt;
        //    ObservableCollection<T_TABELA> ColecaoT_TABELA;

        //    conexao.NomeDaClasse = NomeDaClasse;
        //    conexao.NomeDoMetodo = $"SelecionarDaTabela(Dictionary<string, object> parametros); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
        //    conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}{ProcedimentoArmazenadoSelecionar}";

        //    if (parametros != null)
        //    {
        //        foreach (var keyValuePair in parametros)
        //        {
        //            conexao.AdicionarParametro(keyValuePair.Key, keyValuePair.Value);
        //        }
        //    }

        //    dt = conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: true);

        //    base.ColecaoDeErros = conexao.ColecaoDeErros;

        //    if (dt != null && dt.Rows.Count > 0)
        //        ColecaoT_TABELA = dt.ToObservableCollection<T_TABELA>();
        //    else
        //        ColecaoT_TABELA = new ObservableCollection<T_TABELA>();

        //    foreach (var itemT_TABELA in ColecaoT_TABELA)
        //    {
        //        itemT_TABELA.MarcarRegistrosCarregadosDoBancoDeDados();
        //    }

        //    this.ColecaoDeRegistroDaTabela = ColecaoT_TABELA;

        //    return ColecaoT_TABELA;
        //}

        //public T_TABELA SelecionarDaTabelaPorID(int id)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    parametros.Add("ID", id);

        //    return SelecionarDaTabela(parametros).First();
        //}

        //public T_TABELA SelecionarDaTabelaPorToken(Guid token)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    parametros.Add("TOKEN", token);

        //    return SelecionarDaTabela(parametros).First();
        //}


        //public ObservableCollection<T_VISUALIZACAO> SelecionarDaVisualizacao(Dictionary<string, object> parametros)
        //{
        //    Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();
        //    DataTable dt;
        //    ObservableCollection<T_VISUALIZACAO> ColecaoT_VISUALIZACAO;

        //    conexao.NomeDaClasse = NomeDaClasse;
        //    conexao.NomeDoMetodo = $"SelecionarDaVisualizacao(Dictionary<string, object> parametros); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
        //    conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}_VW{ProcedimentoArmazenadoSelecionar}";

        //    if (parametros != null)
        //    {
        //        foreach (var keyValuePair in parametros)
        //        {
        //            conexao.AdicionarParametro(keyValuePair.Key, keyValuePair.Value);
        //        }
        //    }

        //    dt = conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: true);

        //    base.ColecaoDeErros = conexao.ColecaoDeErros;

        //    if (dt != null && dt.Rows.Count > 0)
        //        ColecaoT_VISUALIZACAO = dt.ToObservableCollection<T_VISUALIZACAO>();
        //    else
        //        ColecaoT_VISUALIZACAO = new ObservableCollection<T_VISUALIZACAO>();

        //    foreach (var itemT_VISUALIZACAO in ColecaoT_VISUALIZACAO)
        //    {
        //        itemT_VISUALIZACAO.MarcarRegistrosCarregadosDoBancoDeDados();
        //    }

        //    this.ColecaoDeRegistroDaVisualizacao = ColecaoT_VISUALIZACAO;

        //    return ColecaoT_VISUALIZACAO;
        //}

        //public T_VISUALIZACAO SelecionarDaVisualizacaoPorID(int id)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    parametros.Add("ID", id);

        //    return SelecionarDaVisualizacao(parametros).First();
        //}

        //public T_VISUALIZACAO SelecionarDaVisualizacaoPorToken(Guid token)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    parametros.Add("TOKEN", token);

        //    return SelecionarDaVisualizacao(parametros).First();
        //}

        //public T_VISUALIZACAO SelecionarDaVisualizacaoPorToken(string token)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    parametros.Add("TOKEN", token);

        //    return SelecionarDaVisualizacao(parametros).First();
        //}

        public ObservableCollection<T_TABELA> SelecionarDaTabela(Dictionary<string, object> parametros)
        {
            Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();
            DataTable dt;

            conexao.NomeDaClasse = NomeDaClasse;
            conexao.NomeDoMetodo = $"SelecionarDaTabela(Dictionary<string, object> parametros); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
            conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}{ProcedimentoArmazenadoSelecionar}";

            if (parametros != null)
            {
                foreach (var keyValuePair in parametros)
                {
                    conexao.AdicionarParametro(keyValuePair.Key, keyValuePair.Value);
                }
            }

            dt = conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: true);

            base.ColecaoDeErros = conexao.ColecaoDeErros;

            if (dt != null && dt.Rows.Count > 0)
                this.ColecaoDeRegistroDaTabela = dt.ToObservableCollection<T_TABELA>();
            else
                this.ColecaoDeRegistroDaTabela = new ObservableCollection<T_TABELA>();

            foreach (var itemT_TABELA in this.ColecaoDeRegistroDaTabela)
            {
                itemT_TABELA.MarcarRegistrosCarregadosDoBancoDeDados();
            }

            return this.ColecaoDeRegistroDaTabela;
        }

        public T_TABELA SelecionarDaTabelaPorID(int id)
        {
            this.Parametros.Clear();
            this.Parametros.Add("ID", id);

            SelecionarDaTabela(this.Parametros);

            this.RegistroDaTabela = this.ColecaoDeRegistroDaTabela.FirstOrDefault();

            return this.RegistroDaTabela;
        }

        public T_TABELA RecarregarRegistroDaTabela()
        {
            if (this.RegistroDaTabela.ID > 0) SelecionarDaTabelaPorID(this.RegistroDaTabela.ID);

            return this.RegistroDaTabela;
        }

        public T_TABELA SelecionarDaTabelaPorToken(Guid token)
        {
            this.Parametros.Clear();
            this.Parametros.Add("TOKEN", token);

            SelecionarDaTabela(this.Parametros);

            this.RegistroDaTabela = this.ColecaoDeRegistroDaTabela.FirstOrDefault();

            return this.RegistroDaTabela;
        }

        public T_TABELA SelecionarDaTabelaPorToken(string token)
        {
            this.Parametros.Clear();
            this.Parametros.Add("TOKEN", token);

            SelecionarDaTabela(this.Parametros);

            this.RegistroDaTabela = this.ColecaoDeRegistroDaTabela.FirstOrDefault();

            return this.RegistroDaTabela;
        }

        public ObservableCollection<T_VISUALIZACAO> SelecionarDaVisualizacao(Dictionary<string, object> parametros)
        {
            Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();
            DataTable dt;

            conexao.NomeDaClasse = NomeDaClasse;
            conexao.NomeDoMetodo = $"SelecionarDaVisualizacao(Dictionary<string, object> parametros); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
            conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}_VW{ProcedimentoArmazenadoSelecionar}";

            if (parametros != null)
            {
                foreach (var keyValuePair in parametros)
                {
                    conexao.AdicionarParametro(keyValuePair.Key, keyValuePair.Value);
                }
            }

            dt = conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: true);

            base.ColecaoDeErros = conexao.ColecaoDeErros;

            if (dt != null && dt.Rows.Count > 0)
                this.ColecaoDeRegistroDaVisualizacao = dt.ToObservableCollection<T_VISUALIZACAO>();
            else
                this.ColecaoDeRegistroDaVisualizacao = new ObservableCollection<T_VISUALIZACAO>();

            foreach (var itemT_VISUALIZACAO in this.ColecaoDeRegistroDaVisualizacao)
            {
                itemT_VISUALIZACAO.MarcarRegistrosCarregadosDoBancoDeDados();
            }

            return this.ColecaoDeRegistroDaVisualizacao;
        }

        public T_VISUALIZACAO SelecionarDaVisualizacaoPorID(int id)
        {
            this.Parametros.Clear();
            this.Parametros.Add("ID", id);

            SelecionarDaVisualizacao(this.Parametros);

            this.RegistroDaVisualizacao = this.ColecaoDeRegistroDaVisualizacao.FirstOrDefault();

            return this.RegistroDaVisualizacao;
        }

        public T_VISUALIZACAO RecarregarRegistroVisualizacao()
        {
            if (this.RegistroDaVisualizacao.ID > 0) SelecionarDaVisualizacaoPorID(this.RegistroDaVisualizacao.ID);

            return this.RegistroDaVisualizacao;
        }

        public T_VISUALIZACAO SelecionarDaVisualizacaoPorToken(Guid token)
        {
            this.Parametros.Clear();
            this.Parametros.Add("TOKEN", token);

            SelecionarDaVisualizacao(this.Parametros);

            this.RegistroDaVisualizacao = this.ColecaoDeRegistroDaVisualizacao.FirstOrDefault();

            return this.RegistroDaVisualizacao;
        }

        public T_VISUALIZACAO SelecionarDaVisualizacaoPorToken(string token)
        {
            this.Parametros.Clear();
            this.Parametros.Add("TOKEN", token);

            SelecionarDaVisualizacao(this.Parametros);

            this.RegistroDaVisualizacao = this.ColecaoDeRegistroDaVisualizacao.FirstOrDefault();

            return this.RegistroDaVisualizacao;
        }

        #endregion Selecionar

        #region Salvar

        protected void Salvar(T_TABELA registroDaTabela)
        {
            base.ColecaoDeErros.Clear();

            Flextech.Infra.ConexaoDeDados.SqlServer conexao = ObterConexaoSqlServer();

            conexao.NomeDaClasse = NomeDaClasse;
            conexao.NomeDoMetodo = $"SalvarNaTabela(registroDaTabela: {typeof(T_TABELA).ToString()}); NomeDoEsquema: {this.NomeDoEsquema}, NomeDaTabela: {this.NomeDaTabela}";
            conexao.ConsultaSql = $"{this.NomeDoEsquema}.{ProcedimentoArmazenadoPrefixo}{this.NomeDaTabela}{ProcedimentoArmazenadoSalvar}";

            foreach (var itemParametro in registroDaTabela.ObterDicionarioDePropriedades())
            {
                if (itemParametro.Key == "ID")
                {
                    conexao.AdicionarParametro("ID", itemParametro.Value, SqlDbType.Int, 0, ParameterDirection.InputOutput);
                    continue;
                }

                conexao.AdicionarParametro(itemParametro.Key, itemParametro.Value);
            }

            conexao.AdicionarParametro("EXECUTADO_COM_SUCESSO", false, SqlDbType.Bit, 0, ParameterDirection.InputOutput);

            conexao.ExecutarConsulta(tipoDoComando: CommandType.StoredProcedure, comRetornoDeDados: false);

            base.ColecaoDeErros = conexao.ColecaoDeErros;

            if (ExisteErro)
                registroDaTabela.ID_NOVO_REGISTRO = 0;
            else
                registroDaTabela.ID_NOVO_REGISTRO = Convert.ToInt32(conexao.ComandoSql.Parameters["ID"].Value);
        }

        public virtual void SalvarNaTabela(T_TABELA registroDaTabela)
        {
            base.ColecaoDeErros.Clear();
            Salvar(registroDaTabela: registroDaTabela);

            if (this.ExisteErro || registroDaTabela.ID_NOVO_REGISTRO < 1) return;

            SelecionarDaTabelaPorID(registroDaTabela.ID_NOVO_REGISTRO);
            registroDaTabela.MarcarRegistrosCarregadosDoBancoDeDados();
        }

        public virtual void SalvarRegistroDaTabela(bool recarregarRegistroDaTabela)
        {
            Salvar(registroDaTabela: RegistroDaTabela);

            if (base.ExisteErro) return;

            if (recarregarRegistroDaTabela)
                SelecionarDaTabelaPorID(this.RegistroDaTabela.ID_NOVO_REGISTRO);
        }
        public virtual void SalvarRegistroDaVisualizacao(bool recarregarRegistroDaVisualizacao)
        {
            Salvar(registroDaTabela: RegistroDaVisualizacao);

            if (base.ExisteErro) return;

            if (recarregarRegistroDaVisualizacao)
                SelecionarDaVisualizacaoPorID(this.RegistroDaVisualizacao.ID_NOVO_REGISTRO);
        }

        #endregion Salvar
    }
}
