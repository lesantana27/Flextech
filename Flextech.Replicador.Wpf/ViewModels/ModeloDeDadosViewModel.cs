/*
==================================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: ViewModels\ModeloDeDadosViewModel.cs
Espaço de nome...: Flextech.Replicador.Wpf.ViewModels
Classe...........: ModeloDeDadosViewModel
Descrição........: Classe View Model da ModeloDeDados
==================================================================================
Criação..........: 12/01/2018 - Lessandro Santana
Alteração........: 22/01/2018 - Lessandro Santana
==================================================================================
*/

using Flextech.Infra.Extensoes;
using Flextech.Infra.Wpf.Comandos;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Flextech.Replicador.Wpf.ViewModels
{
    public partial class ModeloDeDadosViewModel : Flextech.Infra.Wpf.Base.ViewModelBase
    {

        //public ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase> RegistroBaseInterfaceCollection { get { if (this._RegistroBaseInterfaceCollection == null) this._RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(); return this._RegistroBaseInterfaceCollection; } set { ColocarNoCampo(ref this._RegistroBaseInterfaceCollection, value); } }
        //private ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase> _RegistroBaseInterfaceCollection;


        //public Flextech.Replicador.Negocio.Interfaces.IRegistroBase RegistroBaseInterface { get { return this._RegistroBaseInterface; } set { ColocarNoCampo(ref this._RegistroBaseInterface, value); } }
        //private Flextech.Replicador.Negocio.Interfaces.IRegistroBase _RegistroBaseInterface;


        //public Flextech.Replicador.Negocio.Repositorio.Repositorio Repositorio { get { return this._Repositorio; } set { ColocarNoCampo(ref this._Repositorio, value); } }
        //private Flextech.Replicador.Negocio.Repositorio.Repositorio _Repositorio;

        //public Flextech.Replicador.Wpf.ViewModels.CabecalhoUCViewModel CabecalhoUCViewModel { get { return this._CabecalhoUCViewModel; } set { ColocarNoCampo(ref this._CabecalhoUCViewModel, value); } }
        //private Flextech.Replicador.Wpf.ViewModels.CabecalhoUCViewModel _CabecalhoUCViewModel;

        //public Flextech.Replicador.Wpf.Models.TagTreeView TagTreeView { get { return this._TagTreeView; } set { ColocarNoCampo(ref this._TagTreeView, value); } }
        //private Flextech.Replicador.Wpf.Models.TagTreeView _TagTreeView;

        //public DevExpress.Xpf.PropertyGrid.PropertyGridControl CamposPropertyGrid { get { return this._CamposPropertyGrid; } set { ColocarNoCampo(ref this._CamposPropertyGrid, value); } }
        //private DevExpress.Xpf.PropertyGrid.PropertyGridControl _CamposPropertyGrid;

        //#region User Controls

        //public Flextech.Replicador.Wpf.Views.UserControls.ModeloDeDadosUC ModeloDeDadosListarUC { get; set; } = new Flextech.Replicador.Wpf.Views.UserControls.ModeloDeDadosUC();

        //#endregion User Controls

        //#region Commands

        //public ICommand GridControl_CurrentItemChanged_Command
        //{
        //    get { if (_GridControl_CurrentItemChanged_Command == null) _GridControl_CurrentItemChanged_Command = new RelayCommand<object>(GridControl_CurrentItemChanged); return _GridControl_CurrentItemChanged_Command; }
        //}
        //private RelayCommand<object> _GridControl_CurrentItemChanged_Command;

        //public ICommand CamposPropertyGridCommand
        //{
        //    get { if (_CamposPropertyGridCommand == null) _CamposPropertyGridCommand = new RelayCommand<DevExpress.Xpf.PropertyGrid.PropertyGridControl>(CamposPropertyGridComponent); return _CamposPropertyGridCommand; }
        //}
        //private RelayCommand<DevExpress.Xpf.PropertyGrid.PropertyGridControl> _CamposPropertyGridCommand;

        //#endregion Commands

        //#region Actions

        //private void GridControl_CurrentItemChanged(object NotUsed = null)
        //{
        //    if (this.RegistroBaseInterface == null) return;

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.BancoDeDados)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOS = this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOSCollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_BANCO_DE_DADOS>();
        //        this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOS.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOS;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Campo)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_CAMPO = this.Repositorio.RepositorioModelos.VW_CAMPOCollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_CAMPO>();
        //        this.Repositorio.RepositorioModelos.VW_CAMPO.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_CAMPO;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Esquema)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_ESQUEMA = this.Repositorio.RepositorioModelos.VW_ESQUEMACollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_ESQUEMA>();
        //        this.Repositorio.RepositorioModelos.VW_ESQUEMA.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_ESQUEMA;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Tabela)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_TABELA = this.Repositorio.RepositorioModelos.VW_TABELACollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_TABELA>();
        //        this.Repositorio.RepositorioModelos.VW_TABELA.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_TABELA;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.TipoObjetoVisual)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUAL = this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUALCollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_TIPO_OBJETO_VISUAL>();
        //        this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUAL.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUAL;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.TipoPrimitivoCampo)
        //    {
        //        this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPO = this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPOCollection.Where(a => a.ID == this.RegistroBaseInterface.ID).First().CloneData<Flextech.Replicador.ModelosDoGerador.ModeloDeDados.VW_TIPO_PRIMITIVO_CAMPO>();
        //        this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPO.MarcarRegistrosCarregadosDoBancoDeDados();
        //        this.CamposPropertyGrid.SelectedObject = this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPO;
        //        this.CamposPropertyGrid.UpdateLayout();
        //    }
        //}

        //private void CamposPropertyGridComponent(DevExpress.Xpf.PropertyGrid.PropertyGridControl obj)
        //{
        //    this.CamposPropertyGrid = obj;
        //}

        //#endregion Actions

        //public void Atualizar(Flextech.Replicador.Wpf.Models.TagTreeView tagTreeView)
        //{
        //    this.TagTreeView = tagTreeView;
        //    RegistroBaseInterface = null;

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.BancoDeDados)
        //    {
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOSCollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Campo)
        //    {
        //        RegistroBaseInterface = null;
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_CAMPOCollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Esquema)
        //    {
        //        RegistroBaseInterface = null;
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_ESQUEMACollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.Tabela)
        //    {
        //        RegistroBaseInterface = null;
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_TABELACollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.TipoObjetoVisual)
        //    {
        //        RegistroBaseInterface = null;
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUALCollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    if (this.TagTreeView.NomeDoModelo == Models.TagTreeView.NomeDoModeloEnum.TipoPrimitivoCampo)
        //    {
        //        RegistroBaseInterface = null;
        //        RegistroBaseInterfaceCollection = new ObservableCollection<Flextech.Replicador.Negocio.Interfaces.IRegistroBase>(
        //            this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPOCollection.Select(a => (Flextech.Replicador.Negocio.Interfaces.IRegistroBase)a)
        //            );
        //    }

        //    this.ModeloDeDadosListarUC.DataContext = null;
        //    this.ModeloDeDadosListarUC.DataContext = this;
        //}
    }
}
