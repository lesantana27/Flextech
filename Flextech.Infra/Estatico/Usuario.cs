/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Estatico\Usuario.cs
Espaço de nome...: Flextech.Infra.Estatico
Classe...........: Usuario
Descrição........: Informações do usuário para todos os sistemas
==================================================================================
Criação..........: 16/12/2017 - Lessandro Santana
Alteração........: 19/01/2018 - Lessandro Santana
==================================================================================
*/

using System;

namespace Flextech.Infra.Estatico
{
    public static class Usuario
    {
        public static string Nome { get; set; } = "Falta o nome do usuário";
        //public static string NomeDoSistemaPrincipal { get; set; } = "Falta o nome do sistema principal";
        public static string IP { get; set; } = "Falta o IP";
        public static string NomeDoComputador { get; set; } = "Falta o nome do computador";
        public static Guid UsuarioToken { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public static Guid AutenticacaoToken { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public static DateTime AutenticacaoValidaAte { get; set; } = new DateTime();
        public static bool UsuarioAutenticado { get; set; } = false;

        public static void ProcessarParametrosWeb(string p, bool estaCriptografado = false)
        {

        }
    }
}
