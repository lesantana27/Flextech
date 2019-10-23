/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: Estatico\Propriedade.cs
Espaço de nome...: Flextech.Replicador
Classe...........: Estatico -> Propriedade
Descrição........: Propriedades estáticas para uso geral do Replicador
===============================================================================
Criação..........: DD/MM/2019 - Lessandro Santana
Alteração........: DD/MM/2019 - Lessandro Santana
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Replicador
{
    public partial class Estatico
    {
        public static Flextech.Replicador.Repositorio.Repositorio Repositorio { get { if (_Repositorio == null) _Repositorio = new Flextech.Replicador.Repositorio.Repositorio(); return _Repositorio; } set { _Repositorio = value; } }
        private static Flextech.Replicador.Repositorio.Repositorio _Repositorio;

        public static string ExtensaoPadraoDeArquivo { get; set; } = ".replicador.xml";
        public static string FiltroDoDialogoDeArquivo { get; set; } = "Replicador (*.replicador.xml)|*.replicador.xml|Todos (*.*)|*.*";
        public static string TituloDoDialogoDeArquivoAbrir { get; set; } = "Abrir arquivo de dados do Replicador";
        public static string TituloDoDialogoDeArquivoSalvar { get; set; } = "Salvar arquivo de dados do Replicador";
    }
}