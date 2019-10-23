/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra.Static
Arquivo..........: Estatico\BaseDeDados\SqlServer.cs
Espaço de nome...: Flextech.Infra.Estatico.BaseDeDados
Classe...........: SqlServer
Descrição........: Classe estática de propriedades do Sql Server para todos os sistemas
==================================================================================
Criação..........: 16/12/2017 - Lessandro Santana
Alteração........: 23/03/2018 - Lessandro Santana
==================================================================================
*/

namespace Flextech.Infra.Estatico.BaseDeDados
{
    public static class SqlServer
    {

        public static string DataSource { get; set; } = string.Empty;
        public static string InitialCatalog { get; set; } = string.Empty;
        public static string UserID { get; set; } = string.Empty;
        public static string Password { get; set; } = string.Empty;
        public static bool IntegratedSecurity { get; set; } = false;
        public static bool PersistSecurityInfo { get; set; } = false;


        public static void LerConfiguracaoDoAppConfigOuWebConfig()
        {
            DataSource = Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.DataSource");
            InitialCatalog = Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.InitialCatalog");
            UserID = Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.UserID");
            Password = Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.Password");
            IntegratedSecurity = (Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.IntegratedSecurity").ToUpper() == "TRUE");
            PersistSecurityInfo = (Flextech.Infra.Configuracoes.AppSettings.ObterValorDaChave("SqlServer.ConnectionString.PersistSecurityInfo").ToUpper() == "TRUE");
        }

        //public static void LerConfiguracaoDoAppConfigOuWebConfig()
        //{
        //    System.Configuration.Configuration config;
        //    int quantidadeDeChavesDeConfiguracoes;

        //    if (System.Web.Hosting.HostingEnvironment.IsHosted)
        //        config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        //    else
        //        config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

        //    quantidadeDeChavesDeConfiguracoes = config.AppSettings.Settings.Count;

        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.DataSource"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.DataSource", @"Servidor\Instância ou (LocalDB)\MSSQLLocalDB");
        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.InitialCatalog"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.InitialCatalog", @"Nome do banco de dados");
        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.UserID"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.UserID", @"Nome do usuário do banco de dados");
        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.Password"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.Password", @"Senha");
        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.IntegratedSecurity"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.IntegratedSecurity", @"true ou false");
        //    if (config.AppSettings.Settings["SqlServer.ConnectionString.PersistSecurityInfo"] == null) config.AppSettings.Settings.Add("SqlServer.ConnectionString.PersistSecurityInfo", @"true ou false");

        //    if (quantidadeDeChavesDeConfiguracoes != config.AppSettings.Settings.Count)
        //    {
        //        config.Save(System.Configuration.ConfigurationSaveMode.Modified);
        //        System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        //    }

        //    DataSource = config.AppSettings.Settings["SqlServer.ConnectionString.DataSource"].Value;
        //    InitialCatalog = config.AppSettings.Settings["SqlServer.ConnectionString.InitialCatalog"].Value;
        //    UserID = config.AppSettings.Settings["SqlServer.ConnectionString.UserID"].Value;
        //    Password = config.AppSettings.Settings["SqlServer.ConnectionString.Password"].Value;
        //    IntegratedSecurity = (config.AppSettings.Settings["SqlServer.ConnectionString.IntegratedSecurity"].Value.ToUpper() == "TRUE");
        //    PersistSecurityInfo = (config.AppSettings.Settings["SqlServer.ConnectionString.PersistSecurityInfo"].Value.ToUpper() == "TRUE");
        //}
    }
}
