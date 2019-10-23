/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: ViewModels\CampoUnicoUCViewModel.cs
Espaço de nome...: Flextech.Replicador.Wpf.ViewModels
Classe...........: CampoUnicoUCViewModel
Descrição........: 
===============================================================================
Criação..........: 10/01/2019 - Lessandro Santana
Alteração........: 10/01/2019 - Lessandro Santana
===============================================================================
*/

using Flextech.Infra.Extensoes;
using Flextech.Infra.Wpf.Comandos;
using System.Windows;
using System.Windows.Input;

namespace Flextech.Replicador.Wpf.ViewModels
{
    public partial class CampoUnicoUCViewModel : Flextech.Replicador.Wpf.Base.ReplicadorViewModelBase
    {

        #region Propriedades


        public ModeloDeDados.Campo CampoSelecionadoDoGrid { get { return this._CampoSelecionadoDoGrid; } set { ColocarNoCampo(ref this._CampoSelecionadoDoGrid, value); } }
        private ModeloDeDados.Campo _CampoSelecionadoDoGrid;

        public ModeloDeDados.Campo CampoASerEditado { get { return this._CampoASerEditado; } set { ColocarNoCampo(ref this._CampoASerEditado, value); } }
        private ModeloDeDados.Campo _CampoASerEditado;

        public bool ModoConsulta { get { return this._ModoConsulta; } set { ColocarNoCampo(ref this._ModoConsulta, value); } }
        private bool _ModoConsulta = true;

        public bool ModoEdicao { get { return this._ModoEdicao; } set { ColocarNoCampo(ref this._ModoEdicao, value); } }
        private bool _ModoEdicao = false;

        #endregion Propriedades 


        #region Construtor

        public CampoUnicoUCViewModel() : base()
        {

        }

        #endregion Construtor


        #region Comandos

        public ICommand NovoItemCommandprivate 
        {
            get { if (null == _NovoItemCommand) _NovoItemCommand = new RelayCommand(NovoItem); return _NovoItemCommand; }
        }
        private RelayCommand _NovoItemCommand;

        public ICommand EditarItemCommand
        {
            get { if (null == _EditarItemCommand) _EditarItemCommand = new RelayCommand(EditarItem); return _EditarItemCommand; }
        }
        private RelayCommand _EditarItemCommand;..

        public ICommand SalvarItemCommand
        {
            get { if (null == _SalvarItemCommand) _SalvarItemCommand = new RelayCommand(SalvarItem); return _SalvarItemCommand; }
        }
        private RelayCommand _SalvarItemCommand;

        public ICommand ExcluirItemCommand
        {
            get { if (null == _ExcluirItemCommand) _ExcluirItemCommand = new RelayCommand(ExcluirItem); return _ExcluirItemCommand; }
        }
        private RelayCommand _ExcluirItemCommand;

        public ICommand CancelarEdicaoCommand
        {
            get { if (null == _CancelarEdicaoCommand) _CancelarEdicaoCommand = new RelayCommand(CancelarEdicao); return _CancelarEdicaoCommand; }
        }
        private RelayCommand _CancelarEdicaoCommand;

        public ICommand GridControl_CurrentItemChanged_Command
        {
            get { if (null == _GridControl_CurrentItemChanged_Command) _GridControl_CurrentItemChanged_Command = new RelayCommand(GridControl_CurrentItemChanged); return _GridControl_CurrentItemChanged_Command; }
        }
        private RelayCommand _GridControl_CurrentItemChanged_Command;

        #endregion Comandos


        #region Ações dos Comandos

        private void NovoItem(object obj)
        {
            ModeloDeDados.Campo campo = new ModeloDeDados.Campo();

            base.Repositorio.ColecaoDeCamposUnicos.Add(campo);

            this.CampoSelecionadoDoGrid = campo;

            this.CampoASerEditado = this.CampoSelecionadoDoGrid.DeepCopyTo<ModeloDeDados.Campo>();

            Flextech.Replicador.Wpf.Models.ArquivoDeDados.SalvarArquivo();
        }

        private void EditarItem(object obj)
        {
            ModoConsulta = false;
            ModoEdicao = true;


        }

        private void SalvarItem(object obj)
        {
            if (this.CampoSelecionadoDoGrid.NomeDoCampo != this.CampoASerEditado.NomeDoCampo)
            {
                foreach (var itemCampo in base.Repositorio.ColecaoDeCamposUnicos)
                {
                    if (itemCampo.NomeDoCampo.Trim().ToUpper() == this.CampoASerEditado.NomeDoCampo.Trim().ToUpper())
                    {
                        System.Windows.Forms.MessageBox.Show($"O nome do campo {this.CampoASerEditado.NomeDoCampo} já existe. ", "Nome do campo já existe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.CampoSelecionadoDoGrid.PreencherPropriedades(this.CampoASerEditado);
            Flextech.Replicador.Wpf.Models.ArquivoDeDados.SalvarArquivo();

            ModoConsulta = true;
            ModoEdicao = false;
        }

        private void ExcluirItem(object obj)
        {
            if (MessageBox.Show($"Deseja excluir o campo: {this.CampoSelecionadoDoGrid.NomeDoCampo} ?", "Exclusão de Campo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                base.Repositorio.ColecaoDeCamposUnicos.Remove(this.CampoSelecionadoDoGrid);
                Flextech.Replicador.Wpf.Models.ArquivoDeDados.SalvarArquivo();
            }
        }

        private void CancelarEdicao(object obj)
        {
            ModoConsulta = true;
            ModoEdicao = false;
        }

        private void GridControl_CurrentItemChanged(object obj)
        {
            this.CampoASerEditado = this.CampoSelecionadoDoGrid.DeepCopyTo<ModeloDeDados.Campo>();
        }


        #endregion Ações dos Comandos
    }
}