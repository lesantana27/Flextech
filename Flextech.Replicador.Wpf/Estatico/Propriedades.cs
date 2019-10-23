/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: Estatico\Repositorio.cs
Espaço de nome...: Flextech.Replicador.Wpf
Classe...........: Estatico
Descrição........: Classe para as propriedades estática do sistema
===============================================================================
Criação..........: DD/MM/2019 - Lessandro Santana
Alteração........: DD/MM/2019 - Lessandro Santana
===============================================================================
*/


using System.ComponentModel;

namespace Flextech.Replicador.Wpf
{
    public partial class Estatico
    {
        public static string NomeDaTelaPrincipal
        {
            get
            {
                string nomeDaTela = "Replicador 2019";

                if (string.IsNullOrEmpty(_NomeDaTelaPrincipal))
                    return nomeDaTela;

                return $"{nomeDaTela} - {_NomeDaTelaPrincipal}";
            }
            set { _NomeDaTelaPrincipal = value; }
        }
        private static string _NomeDaTelaPrincipal;

        #region Windows Views


        public static Flextech.Replicador.Wpf.Views.Windows.PrincipalWindow PrincipalWindow { get { if (_PrincipalWindow == null) _PrincipalWindow = new Flextech.Replicador.Wpf.Views.Windows.PrincipalWindow(); return _PrincipalWindow; } private set { _PrincipalWindow = value; } }
        private static Flextech.Replicador.Wpf.Views.Windows.PrincipalWindow _PrincipalWindow;

        #endregion Windows Views
    }
}