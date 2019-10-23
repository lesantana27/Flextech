/*
===============================================================================
Solução..........: Flextech
Projeto..........: Infra.Web
Arquivo..........: Base\ControlerBase.cs
Espaço de nome...: Flextech.Infra.Web.Base
Classe...........: ControlerBase
Descrição........: Controller base para todos os projetos web
===============================================================================
Criação..........: 21/02/2018 - Lessandro Santana
Alteração........: 23/03/2018 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;

namespace Flextech.Infra.Web.Base
{
    public class ControllerBase : System.Web.Mvc.Controller, Flextech.Infra.Web.Interfaces.IControllerBase
    {
        public virtual Flextech.Infra.Web.Classes.Enderecos Enderecos { get { if (this._Enderecos == null) this._Enderecos = new Flextech.Infra.Web.Classes.Enderecos(); return this._Enderecos; } set { this._Enderecos = value; } }
        private Flextech.Infra.Web.Classes.Enderecos _Enderecos;

        public virtual Flextech.Infra.Web.Classes.Parametros Parametros { get { if (this._Parametros == null) this._Parametros = new Flextech.Infra.Web.Classes.Parametros(); return this._Parametros; } set { this._Parametros = value; } }
        private Flextech.Infra.Web.Classes.Parametros _Parametros;

        public virtual Flextech.Infra.Web.Classes.VariaveisDoServidor VariaveisDoServidor { get { if (this._VariaveisDoServidor == null) this._VariaveisDoServidor = new Flextech.Infra.Web.Classes.VariaveisDoServidor(); return this._VariaveisDoServidor; } set { this._VariaveisDoServidor = value; } }
        private Flextech.Infra.Web.Classes.VariaveisDoServidor _VariaveisDoServidor;

        public virtual string NomeDoComputador { get { return this.VariaveisDoServidor.REMOTE_HOST; } }

        public virtual string EnderecoIP { get { return this.VariaveisDoServidor.REMOTE_ADDR; } }

        public virtual string NomeDoUsuario { get { return this._NomeDoUsuario; } set { this._NomeDoUsuario = value; } }
        private string _NomeDoUsuario = "Sistema Web";

        public virtual string TokenUsuario { get; private set; }
        public virtual string TokenEmpresa { get; private set; }
        public virtual string Esquema { get; private set; }
        public virtual string Tabela { get; private set; }
        public virtual string Acao { get; private set; }
        public virtual string Parametro { get; private set; }

        public ControllerBase() : base()
        {
            ViewBag.ExisteErro = false;
            ViewBag.TextoDaMensagemDeErro = "";
            ViewBag.EnderecoBase = this.Enderecos.Engenharia;
        }

        public virtual void AnalisarDadosDeRoteamento()
        {
            //string controller = this.RouteData.Values["controller"].ToString();     // o controller = esquema do banco de dados
            //string action = this.RouteData.Values["action"].ToString();             // o action => Obter = get / Postar = post

            this.TokenUsuario = this.RouteData.Values["tokenUsuario"].ToString();
            this.TokenEmpresa = this.RouteData.Values["tokenEmpresa"].ToString();
            this.Esquema = this.RouteData.Values["controller"].ToString();
            this.Tabela = this.RouteData.Values["tabela"].ToString();
            this.Acao = this.RouteData.Values["acao"].ToString();
            this.Parametro = this.RouteData.Values["parametro"].ToString();



            ViewBag.Controller = this.RouteData.Values["controller"].ToString();     // o controller = esquema do banco de dados
            ViewBag.Action = this.RouteData.Values["action"].ToString();             // o action => Obter = get / Postar = post

            ViewBag.TokenUsuario = this.TokenUsuario;
            ViewBag.TokenEmpresa = this.TokenEmpresa;
            ViewBag.Esquema = this.Esquema;
            ViewBag.Tabela = this.Tabela;
            ViewBag.Acao = this.Acao;
            ViewBag.Parametro = this.Parametro;
        }

        public virtual void AnalisarParametros()
        {
            string p;
            string[] parametros;
            string[] parametro;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            try
            {
                p = System.Web.HttpContext.Current.Request.QueryString["p"];

                if (p == null) return;

                ViewBag.pAnterior = p.ToString();

                // a=123;r=asd;c=;
                parametros = p.ToString().Split(';');

                for (int i = 0; i < parametros.Length; i++)
                {
                    parametro = parametros[i].Split('=');

                    if (parametro.Length == 2)
                        if (!string.IsNullOrEmpty(parametro[0]))
                            if (!string.IsNullOrEmpty(parametro[1]))
                                dic.Add(parametro[0], parametro[1]);
                            else
                                dic.Add(parametro[0], "");

                    if (parametro.Length == 1)
                        if (!string.IsNullOrEmpty(parametro[0]))
                            dic.Add(parametro[0], "");
                }

                Parametros.PopularParametros(dic);
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                ViewBag.Parametros = this.Parametros;
            }
        }

        public virtual void AnalizarVariaveisDoServidor()
        {
            VariaveisDoServidor.HTTP_USER_AGENT = System.Web.HttpContext.Current.Request.ServerVariables.Get("HTTP_USER_AGENT");
            VariaveisDoServidor.REMOTE_ADDR = System.Web.HttpContext.Current.Request.ServerVariables.Get("REMOTE_ADDR");
            VariaveisDoServidor.REMOTE_HOST = System.Web.HttpContext.Current.Request.ServerVariables.Get("REMOTE_HOST");

            ViewBag.NomeDoComputador = this.NomeDoComputador;
            ViewBag.EnderecoIP = this.EnderecoIP;
            ViewBag.NomeDoUsuario = this.NomeDoUsuario;
        }

        public virtual void AutenticarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public virtual void AutenticarUsuario(string tokenAutenticacao)
        {
            throw new NotImplementedException();
        }

        public virtual void ValidarChamada()
        {
            //TODO: Falta implementar -> Flextech.Infra.Web.Base.ControllerBase.ValidarChamada()
            //throw new NotImplementedException();

            AnalizarVariaveisDoServidor();
            AnalisarDadosDeRoteamento();
            AnalisarParametros();
        }

        public virtual void Navegar(string enderecoDaPaginaDeDestino = "")
        {
            if (!string.IsNullOrEmpty(enderecoDaPaginaDeDestino)) this.Response.Redirect(enderecoDaPaginaDeDestino);

            if (!string.IsNullOrEmpty(this.Parametros.pnr)) this.Response.Redirect(this.Parametros.pnr);

            this.Response.Redirect(this.Enderecos.Controle + this.Parametros.ObterParametros());
        }

        public virtual void PreencherObjetoComDadosDoForm<T>(ref T objeto)
        {
            bool valorBoolean;
            string valorString;
            Guid valorGuid;
            DateTime valorDateTime;
            int valorInt32;
            decimal valorDecimal;

            foreach (var propertyInfo in objeto.GetType().GetProperties())
            {
                if (propertyInfo.GetCustomAttributes(typeof(System.Runtime.Serialization.DataMemberAttribute), true).Length == 0) continue;
                if (propertyInfo.CanWrite == false) continue;

                valorString = this.Request.Form.Get(propertyInfo.Name.ToLower());

                switch (propertyInfo.PropertyType.FullName)
                {
                    case "System.Boolean":
                        valorBoolean = false;
                        bool.TryParse(valorString, out valorBoolean);
                        propertyInfo.SetValue(objeto, valorBoolean);
                        break;
                    case "System.DateTime":
                        valorDateTime = DateTime.Now;
                        DateTime.TryParse(valorString, out valorDateTime);
                        propertyInfo.SetValue(objeto, valorDateTime);
                        break;
                    case "System.Decimal":
                        valorDecimal = 0;
                        decimal.TryParse(valorString, out valorDecimal);
                        propertyInfo.SetValue(objeto, valorDecimal);
                        break;
                    case "System.Guid":
                        valorGuid = new Guid("00000000-0000-0000-0000-000000000000");
                        Guid.TryParse(valorString, out valorGuid);
                        propertyInfo.SetValue(objeto, valorGuid);
                        break;
                    case "System.Int32":
                        valorInt32 = 0;
                        int.TryParse(valorString, out valorInt32);
                        propertyInfo.SetValue(objeto, valorInt32);
                        break;
                    case "System.String":
                        propertyInfo.SetValue(objeto, valorString);
                        break;
                    default:
                        break;
                }


            }
        }


    }
}
