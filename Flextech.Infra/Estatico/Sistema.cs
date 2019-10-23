/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Estatico\Sistema.cs
Espaço de nome...: Flextech.Infra.Estatico
Classe...........: Sistema
Descrição........: Informações do sistema
==================================================================================
Criação..........: 06/02/2018 - Lessandro Santana
Alteração........: 06/02/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.Estatico
{
    public static class Sistema
    {
        public static string NomeUsuario { get; set; } = "Falta o nome do usuário";
        public static string EnderecoIP { get; set; } = "Falta o IP";
        public static string NomeComputador { get; set; } = "Falta o nome do computador";
    }

    public enum NomeDoSistema
    {
        NENHUM,
        WEB_AUTENTICACAO,
        WEB_ENGENHARIA
    }
}
