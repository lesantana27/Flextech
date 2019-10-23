/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Configuracoes\AppSettings.cs
Espaço de nome...: Flextech.Infra.Configuracoes
Classe...........: AppSettings
Descrição........: Classe para ler o AppSettings e interpretar os valores por máquina
==================================================================================
Criação..........: 15/12/2017 - Lessandro Santana
Alteração........: 22/01/2018 - Lessandro Santana
==================================================================================
*/

namespace Flextech.Infra.Configuracoes
{
    public class AppSettings
    {
        private static string NomeDoComputador { get; set; } = string.Empty;
        private static string PrefixoDoComputador { get; set; } = string.Empty;

        public static string ObterValorDaChave(string chave)
        {
            string valor = $"ERRO: Chave não encontrada -> {chave} <- no App.config ou Web.config. ";

            if (string.IsNullOrEmpty(NomeDoComputador))
                NomeDoComputador = @System.Environment.MachineName.ToUpper();

            PrefixoDoComputador = @System.Configuration.ConfigurationManager.AppSettings[NomeDoComputador];
            if (string.IsNullOrEmpty(PrefixoDoComputador))
            {
                throw new System.Exception($"ERRO: Chave não encontrada -> {NomeDoComputador} <- no App.config ou Web.config. Adicionar no appSettings <add key=\"{NomeDoComputador}\" value =\"{NomeDoComputador}__\" />");
            }

            valor = @System.Configuration.ConfigurationManager.AppSettings[$"{PrefixoDoComputador}{chave}"];
            if (string.IsNullOrEmpty(valor))
            {
                throw new System.Exception($"ERRO: Chave não encontrada -> {PrefixoDoComputador}{chave} <- no App.config ou Web.config. Adicionar no appSettings <add key=\"{PrefixoDoComputador}{chave}\" value =\"Valor da chave\" />");
            }

            return valor;
        }
    }
}
