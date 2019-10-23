/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: RegistradorBasico.cs
Espaço de nome...: Flextech.Infra.Registrador
Classe...........: RegistradorBasico
Descrição........: Registrador básico para todos os sistemas
==================================================================================
Criação..........: 15/12/2017 - Lessandro Santana
Alteração........: 19/09/2019 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Flextech.Infra.Registrador
{
    public class RegistradorBasico : Flextech.Infra.Base.ObjetoBase
    {
        public string Diretorio { get { return this._Diretorio; } private set { ColocarNoCampo(ref this._Diretorio, value); } }
        private string _Diretorio = @System.Environment.CurrentDirectory + @"\_Registrador\";

        public string NomeDoArquivoDeRegistro { get { return this._NomeDoArquivoDeRegistro; } private set { ColocarNoCampo(ref this._NomeDoArquivoDeRegistro, value); } }
        private string _NomeDoArquivoDeRegistro = "Geral_";

        public RegistradorBasico(string diretorio = null, string nomeDoArquivoDeRegistro = null)
        {
            if (diretorio != null) this.Diretorio = diretorio;
            if (this.NomeDoArquivoDeRegistro != null) this.NomeDoArquivoDeRegistro = nomeDoArquivoDeRegistro;

            if (!Directory.Exists(this.Diretorio)) Directory.CreateDirectory(this.Diretorio);
        }

        private void Registrar(string mensagem)
        {
            StreamWriter sw;
            string file = this.Diretorio + this.NomeDoArquivoDeRegistro + string.Format("{0:yyyy_MM_dd}", DateTime.Now) + ".log";

            sw = File.AppendText(file);
            sw.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", DateTime.Now) + " - " + mensagem);
            sw.Close();

            System.Console.WriteLine(mensagem);
        }

        public void RegistrarLog(string mensagem)
        {
            Registrar("");
            Registrar("*** LOG ***");
            Registrar($"Mensagem --------> {mensagem}");
            Registrar($"User Name -------> {Flextech.Infra.Estatico.Usuario.Nome}");
            Registrar("");
        }

        public void RegistrarErro(string mensagemDeErro)
        {
            Registrar("");
            Registrar("*** ERRO ***");
            Registrar($"Mensagem --------> {mensagemDeErro}");
            Registrar($"User Name -------> {Flextech.Infra.Estatico.Usuario.Nome}");
            Registrar("");
        }

        public void RegistrarExcecao(string nomeDaClasse, string nomeDoMetodo, string nomeDoUsuario, object objetoDeExcecao)
        {

            Registrar("");
            Registrar("*** EXCEPTION ***");
            Registrar($"Class Name ------> {nomeDaClasse}");
            Registrar($"Method Name -----> {nomeDoMetodo}");
            Registrar($"User Name -------> {nomeDoUsuario}");
            Registrar($"User Name -------> {Flextech.Infra.Estatico.Usuario.Nome}");
            Registrar($"Type ------------> {objetoDeExcecao.GetType().Name}");

            if (objetoDeExcecao is System.Exception)
            {
                System.Exception e = objetoDeExcecao as System.Exception;

                Registrar($"HelpLink --------> {e.HelpLink}");
                Registrar($"HResult ---------> {e.HResult.ToString()}");
                Registrar($"Message ---------> {e.Message}");
                Registrar($"Source ----------> {e.Source}");
                Registrar($"StackTrace ------> {e.StackTrace}");
            }

            if (objetoDeExcecao is System.Data.SqlClient.SqlException)
            {
                System.Data.SqlClient.SqlException e = objetoDeExcecao as System.Data.SqlClient.SqlException;

                Registrar($"HelpLink --------> {e.HelpLink}");
                Registrar($"HResult ---------> {e.HResult.ToString()}");
                Registrar($"LineNumber ------> {e.LineNumber.ToString()}");
                Registrar($"Message ---------> {e.Message}");
                Registrar($"Number ----------> {e.Number.ToString()}");
                Registrar($"Procedure -------> {e.Procedure}");
                Registrar($"Server ----------> {e.Server}");
                Registrar($"Source ----------> {e.Source}");
                Registrar($"StackTrace ------> {e.StackTrace}");
            }

            Registrar("");
        }

        public void RegistrarExcecaoDeBancoDeDados(string nomeDaClasse, string nomeDoMetodo, string consultaSql, Dictionary<string, string> parametrosSql, object objetoDeExcecao)
        {

            Registrar("");
            Registrar("*** DATABASE EXCEPTION ***");
            Registrar($"User Name -------> {Flextech.Infra.Estatico.Usuario.Nome}");
            Registrar($"Class Name ------> {nomeDaClasse}");
            Registrar($"Method Name -----> {nomeDoMetodo}");
            Registrar($"Query -----------> {consultaSql}");
            foreach (var item in parametrosSql)
            {
                Registrar($"Parameter -------> Parameter: {item.Key} - Value: {item.Value}");
            }
            Registrar($"Type ------------> {objetoDeExcecao.GetType().Name}");

            if (objetoDeExcecao is System.Exception)
            {
                System.Exception e = objetoDeExcecao as System.Exception;

                Registrar($"HelpLink --------> {e.HelpLink}");
                Registrar($"HResult ---------> {e.HResult.ToString()}");
                Registrar($"Message ---------> {e.Message}");
                Registrar($"Source ----------> {e.Source}");
                Registrar($"StackTrace ------> {e.StackTrace}");
            }

            if (objetoDeExcecao is System.Data.SqlClient.SqlException)
            {
                System.Data.SqlClient.SqlException e = objetoDeExcecao as System.Data.SqlClient.SqlException;

                Registrar($"HelpLink --------> {e.HelpLink}");
                Registrar($"HResult ---------> {e.HResult.ToString()}");
                Registrar($"LineNumber ------> {e.LineNumber.ToString()}");
                Registrar($"Message ---------> {e.Message}");
                Registrar($"Number ----------> {e.Number.ToString()}");
                Registrar($"Procedure -------> {e.Procedure}"); ;
                Registrar($"Server ----------> {e.Server}");
                Registrar($"Source ----------> {e.Source}");
                Registrar($"StackTrace ------> {e.StackTrace}");
            }

            Registrar("");
        }

    }
}