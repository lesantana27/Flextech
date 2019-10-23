/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: ViewModels\MenuPrincipalViewModel.cs
Espaço de nome...: Flextech.Replicador.Wpf.ViewModels
Classe...........: MenuPrincipalViewModel
Descrição........: View model do menu principal
===============================================================================
Criação..........: 09/01/2019 - Lessandro Santana
Alteração........: 09/01/2019 - Lessandro Santana
===============================================================================
*/

using Flextech.Infra.Wpf.Comandos;
using System.Windows.Input;

namespace Flextech.Replicador.Wpf.ViewModels
{
    public partial class MenuPrincipalViewModel : Flextech.Replicador.Wpf.Base.ReplicadorViewModelBase
    {

        #region Comandos

        public ICommand NovoCommand
        {
            get { if (null == _NovoCommand) _NovoCommand = new RelayCommand(NovoRepositorio); return _NovoCommand; }
        }
        private RelayCommand _NovoCommand;

        public ICommand AbrirCommand
        {
            get { if (null == _AbrirCommand) _AbrirCommand = new RelayCommand(AbrirRepositorio); return _AbrirCommand; }
        }
        private RelayCommand _AbrirCommand;

        public ICommand SalvarCommand
        {
            get { if (null == _SalvarCommand) _SalvarCommand = new RelayCommand(SalvarRepositorio); return _SalvarCommand; }
        }
        private RelayCommand _SalvarCommand;

        #endregion Comandos


        #region Ações dos Comandos

        private void NovoRepositorio(object naoUsado = null)
        {
            Flextech.Replicador.Wpf.Models.ArquivoDeDados.NovoArquivo();
        }

        private void AbrirRepositorio(object naoUsado = null)
        {
            Flextech.Replicador.Wpf.Models.ArquivoDeDados.AbrirArquivo();
        }

        private void SalvarRepositorio(object naoUsado = null)
        {
            Flextech.Replicador.Wpf.Models.ArquivoDeDados.SalvarArquivo();
        }

        #endregion Ações dos Comandos




    }
}