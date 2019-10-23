/*
==================================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: ViewModels\PrincipalWindowViewModel.cs
Espaço de nome...: Flextech.Replicador.Wpf.ViewModels
Classe...........: PrincipalWindowViewModel
Descrição........: Classe View Model da PrincipalWindow
==================================================================================
Criação..........: 02/01/2018 - Lessandro Santana
Alteração........: 22/01/2018 - Lessandro Santana
==================================================================================
*/

using Flextech.Infra.Wpf.Comandos;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Flextech.Replicador.Wpf.ViewModels
{
    public partial class PrincipalWindowViewModel : Flextech.Replicador.Wpf.Base.ReplicadorViewModelBase
    {

        #region Propriedades 

        

        #endregion Propriedades 

        //public Flextech.Infra.Utilitarios.Arquivo ArquivoUtil { get { if (this._ArquivoUtil == null) this._ArquivoUtil = new Flextech.Infra.Utilitarios.Arquivo(); return this._ArquivoUtil; } set { ColocarNoCampo(ref this._ArquivoUtil, value); } }
        //private Flextech.Infra.Utilitarios.Arquivo _ArquivoUtil;

        //public Flextech.Infra.Utilitarios.SerializadorXml SerializadorXmlUtil { get { if (this._SerializadorXmlUtil == null) this._SerializadorXmlUtil = new Flextech.Infra.Utilitarios.SerializadorXml(); return this._SerializadorXmlUtil; } set { ColocarNoCampo(ref this._SerializadorXmlUtil, value); } }
        //private Flextech.Infra.Utilitarios.SerializadorXml _SerializadorXmlUtil;


        //public Flextech.Replicador.Negocio.Repositorio.Repositorio Repositorio { get { if (this._Repositorio == null) this._Repositorio = new Flextech.Replicador.Negocio.Repositorio.Repositorio(); return this._Repositorio; } set { ColocarNoCampo(ref this._Repositorio, value); } }
        //private Flextech.Replicador.Negocio.Repositorio.Repositorio _Repositorio;

        #region Propriedades Screen Controls

        //public System.Windows.Controls.Grid CabecalhoGrid { get { return this._CabecalhoGrid; } set { ColocarNoCampo(ref this._CabecalhoGrid, value); } }
        //private System.Windows.Controls.Grid _CabecalhoGrid;

        //public System.Windows.Controls.Grid TreeViewGrid { get { return this._TreeViewGrid; } set { ColocarNoCampo(ref this._TreeViewGrid, value); } }
        //private System.Windows.Controls.Grid _TreeViewGrid;

        //public System.Windows.Controls.Grid ConteudoGrid { get { return this._ConteudoGrid; } set { ColocarNoCampo(ref this._ConteudoGrid, value); } }
        //private System.Windows.Controls.Grid _ConteudoGrid;

        //public System.Windows.Controls.Grid RodapeGrid { get { return this._RodapeGrid; } set { ColocarNoCampo(ref this._RodapeGrid, value); } }
        //private System.Windows.Controls.Grid _RodapeGrid;

        #endregion Propriedades Screen Controls


        #region User Controls

        //public Flextech.Replicador.Wpf.Views.UserControls.CabecalhoUC CabecalhoUC { get; set; } = new Flextech.Replicador.Wpf.Views.UserControls.CabecalhoUC();

        //public Flextech.Replicador.Wpf.Views.UserControls.RodapeUC RodapeUC { get; set; } = new Flextech.Replicador.Wpf.Views.UserControls.RodapeUC();

        #endregion User Controls


        #region View Models


        //public Flextech.Replicador.Wpf.ViewModels.CabecalhoUCViewModel CabecalhoUCViewModel { get { if (this._CabecalhoUCViewModel == null) this._CabecalhoUCViewModel = new Flextech.Replicador.Wpf.ViewModels.CabecalhoUCViewModel(); return this._CabecalhoUCViewModel; } set { ColocarNoCampo(ref this._CabecalhoUCViewModel, value); } }
        //private Flextech.Replicador.Wpf.ViewModels.CabecalhoUCViewModel _CabecalhoUCViewModel;

        //public Flextech.Replicador.Wpf.ViewModels.ModeloDeDadosViewModel ModeloDeDadosViewModel { get { if (this._ModeloDeDadosViewModel == null) this._ModeloDeDadosViewModel = new Flextech.Replicador.Wpf.ViewModels.ModeloDeDadosViewModel(); return this._ModeloDeDadosViewModel; } set { ColocarNoCampo(ref this._ModeloDeDadosViewModel, value); } }
        //private Flextech.Replicador.Wpf.ViewModels.ModeloDeDadosViewModel _ModeloDeDadosViewModel;

        #endregion View Models


        #region Construtor

        public PrincipalWindowViewModel() : base()
        {
            base.NomeDaTela = Wpf.Estatico.NomeDaTelaPrincipal;

            //this.Repositorio.CarregarDados();

            //this.ModeloDeDadosViewModel.Repositorio = this.Repositorio;
            //this.ModeloDeDadosViewModel.CabecalhoUCViewModel = this.CabecalhoUCViewModel;
        }

        #endregion Construtor


        #region Commands 

        //public ICommand CabecalhoGridCommand
        //{
        //    get { if (_CabecalhoGridCommand == null) _CabecalhoGridCommand = new RelayCommand<System.Windows.Controls.Grid>(CabecalhoGridComponent); return _CabecalhoGridCommand; }
        //}
        //private RelayCommand<System.Windows.Controls.Grid> _CabecalhoGridCommand;

        //public ICommand TreeViewGridCreateCommand
        //{
        //    get { if (_TreeViewGridCreateCommand == null) _TreeViewGridCreateCommand = new RelayCommand<System.Windows.Controls.Grid>(TreeViewGridCreate); return _TreeViewGridCreateCommand; }
        //}
        //private RelayCommand<System.Windows.Controls.Grid> _TreeViewGridCreateCommand;

        //public ICommand ConteudoGridCommand
        //{
        //    get { if (_ConteudoGridCommand == null) _ConteudoGridCommand = new RelayCommand<System.Windows.Controls.Grid>(ConteudoGridComponent); return _ConteudoGridCommand; }
        //}
        //private RelayCommand<System.Windows.Controls.Grid> _ConteudoGridCommand;

        //public ICommand RodapeGridCommand
        //{
        //    get { if (_RodapeGridCommand == null) _RodapeGridCommand = new RelayCommand<System.Windows.Controls.Grid>(RodapeGridComponent); return _RodapeGridCommand; }
        //}
        //private RelayCommand<System.Windows.Controls.Grid> _RodapeGridCommand;

        #endregion Commands


        #region Actions of Commands

        //private void CabecalhoGridComponent(System.Windows.Controls.Grid cabecalhoGrid)
        //{
        //    this.CabecalhoGrid = cabecalhoGrid;

        //    this.CabecalhoUC.DataContext = this.CabecalhoUCViewModel;

        //    this.CabecalhoGrid.Children.Clear();
        //    this.CabecalhoGrid.Children.Add(this.CabecalhoUC);

        //}

        //private void TreeViewGridCreate(System.Windows.Controls.Grid treeViewGrid)
        //{
        //    this.TreeViewGrid = treeViewGrid;

        //    this.TreeViewGrid.Children.Clear();

        //    CriarTreeView();
        //}

        //private void ConteudoGridComponent(System.Windows.Controls.Grid ConteudoGrid)
        //{
        //    this.ConteudoGrid = ConteudoGrid;
        //}

        //private void RodapeGridComponent(System.Windows.Controls.Grid RodapeGrid)
        //{
        //    this.RodapeGrid = RodapeGrid;
        //}

        #endregion  Actions of Commands


        #region Tree View
        //private void CriarTreeView()
        //{
        //    TreeView treeView = new TreeView();
        //    treeView.Margin = new System.Windows.Thickness(10);
        //    TreeViewItem modeloDeDadosTreeViewItem;

        //    // Data Model
        //    modeloDeDadosTreeViewItem = new TreeViewItem()
        //    {
        //        Header = "Modelo de Dados",
        //        IsExpanded = true,
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //        }
        //    };

        //    modeloDeDadosTreeViewItem.Selected += TreeViewItem_Selected;

        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosBancoDeDadosTreeViewItems());
        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosCampoTreeViewItems());
        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosEsquamaTreeViewItems());
        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosTabelaTreeViewItems());
        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosTipoPrimitivoCampoTreeViewItems());
        //    modeloDeDadosTreeViewItem.Items.Add(CriarModeloDeDadosTipoObjetoVisualTreeViewItems());
        //    treeView.Items.Add(modeloDeDadosTreeViewItem);

        //    // Persistence Model
        //    treeView.Items.Add(CriarModeloDePersistenciaTreeViewItem());

        //    this.TreeViewGrid.Children.Add(treeView);
        //}

        //private void TreeViewItem_Selected(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    if (((TreeViewItem)sender).Tag == null) return;

        //    Flextech.Replicador.Wpf.Models.TagTreeView tagTreeView = new Models.TagTreeView();

        //    if (sender is TreeViewItem)
        //        tagTreeView = ((TreeViewItem)sender).Tag as Flextech.Replicador.Wpf.Models.TagTreeView;

        //    this.ConteudoGrid.Children.Clear();

        //    if (tagTreeView.RaizDaTreeView == Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados) MostrarModeloDeDadosUserControls(tagTreeView);
        //    if (tagTreeView.RaizDaTreeView == Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia) ShowPersistenceModelUserControls(tagTreeView);

        //    if (this.ConteudoGrid.Children.Count == 0) this.ConteudoGrid.Children.Add(new Label() { Content = $"{((TreeViewItem)sender).Tag.ToString()} não encontrado em TreeViewItem_Selected(object sender, System.Windows.RoutedEventArgs e)" });

        //    e.Handled = true;

        //    this.CabecalhoUCViewModel.TagTreeView = tagTreeView;
        //}

        #region Data Model

        //private TreeViewItem CriarModeloDeDadosBancoDeDadosTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Bases de dados ({this.Repositorio.RepositorioModelos.VW_BANCO_DE_DADOSCollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.BancoDeDados,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        //private TreeViewItem CriarModeloDeDadosCampoTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Campos ({this.Repositorio.RepositorioModelos.VW_CAMPOCollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Campo,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        //private TreeViewItem CriarModeloDeDadosEsquamaTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Esquemas ({this.Repositorio.RepositorioModelos.VW_ESQUEMACollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Esquema,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        //private TreeViewItem CriarModeloDeDadosTabelaTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Tabelas ({this.Repositorio.RepositorioModelos.VW_TABELACollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Tabela,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        //private TreeViewItem CriarModeloDeDadosTipoObjetoVisualTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Tipos de objetos visuais ({this.Repositorio.RepositorioModelos.VW_TIPO_OBJETO_VISUALCollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.TipoObjetoVisual,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        //private TreeViewItem CriarModeloDeDadosTipoPrimitivoCampoTreeViewItems()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"Tipos primitivos de campos ({this.Repositorio.RepositorioModelos.VW_TIPO_PRIMITIVO_CAMPOCollection.Count})",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDeDados,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.TipoPrimitivoCampo,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Listar
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    return treeViewItemParent;
        //}

        #endregion Data Model

        #region Persistence Model

        //public TreeViewItem CriarModeloDePersistenciaTreeViewItem()
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = "Modelo de Persistência",
        //        IsExpanded = true,
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    foreach (var item in this.Repositorio.RepositorioTabelas.VW_BANCO_DE_DADOSCollection)
        //    {
        //        treeViewItemParent.Items.Add(CriarModeloDePersistenciaBancoDeDadosTreeViewItem(item));
        //    }

        //    return treeViewItemParent;
        //}

        //public TreeViewItem CriarModeloDePersistenciaBancoDeDadosTreeViewItem(Flextech.Replicador.ModelosDoGerador.ModeloDePersistencia.VW_BANCO_DE_DADOS vw_banco_de_dados)
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"{vw_banco_de_dados.NOME} ({this.Repositorio.RepositorioTabelas.VW_ESQUEMACollection.Count} Esquemas)",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.BancoDeDados,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Editar,
        //            ID = vw_banco_de_dados.ID
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    foreach (var item in this.Repositorio.RepositorioTabelas.VW_ESQUEMACollection.Where(a => a.MODELO_DE_DADOS__BANCO_DE_DADOS__ID == vw_banco_de_dados.MODELO_DE_DADOS__BANCO_DE_DADOS__ID))
        //    {
        //        treeViewItemParent.Items.Add(CriarModeloDePersistenciaEsquemaTreeViewItem(item));
        //    }

        //    return treeViewItemParent;
        //}

        //public TreeViewItem CriarModeloDePersistenciaEsquemaTreeViewItem(Flextech.Replicador.ModelosDoGerador.ModeloDePersistencia.VW_ESQUEMA vw_esquema)
        //{
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"{vw_esquema.NOME} ({this.Repositorio.RepositorioTabelas.VW_TABELACollection.Where(a => a.MODELO_DE_DADOS__BANCO_DE_DADOS__ID == vw_esquema.MODELO_DE_DADOS__BANCO_DE_DADOS__ID && a.MODELO_DE_DADOS__ESQUEMA__ID == vw_esquema.MODELO_DE_DADOS__ESQUEMA__ID).Count()} Tabelas)",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Esquema,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Editar,
        //            ID = vw_esquema.ID
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;

        //    foreach (var item in this.Repositorio.RepositorioTabelas.VW_TABELACollection.Where(a => a.MODELO_DE_DADOS__BANCO_DE_DADOS__ID == vw_esquema.MODELO_DE_DADOS__BANCO_DE_DADOS__ID && a.MODELO_DE_DADOS__ESQUEMA__ID == vw_esquema.MODELO_DE_DADOS__ESQUEMA__ID).OrderBy(a => a.NOME))
        //    {
        //        treeViewItemParent.Items.Add(CriarModeloDePersistenciaTabelaTreeViewItem(item));
        //    }

        //    return treeViewItemParent;
        //}

        //public TreeViewItem CriarModeloDePersistenciaTabelaTreeViewItem(Flextech.Replicador.ModelosDoGerador.ModeloDePersistencia.VW_TABELA vw_tabela)
        //{
        //    ObservableCollection<Flextech.Replicador.ModelosDoGerador.ModeloDePersistencia.VW_CAMPO> vw_campoCollection = new ObservableCollection<Flextech.Replicador.ModelosDoGerador.ModeloDePersistencia.VW_CAMPO>(
        //        this.Repositorio.RepositorioTabelas.VW_TABELA_CAMPOCollection.Where(a =>
        //        a.MODELO_DE_DADOS__BANCO_DE_DADOS__ID == vw_tabela.MODELO_DE_DADOS__BANCO_DE_DADOS__ID &&
        //        a.MODELO_DE_DADOS__ESQUEMA__ID == vw_tabela.MODELO_DE_DADOS__ESQUEMA__ID &&
        //        a.MODELO_DE_DADOS__TABELA__ID == vw_tabela.MODELO_DE_DADOS__TABELA__ID).
        //        OrderBy(a => a.ORDEM_SEQUENCIAL_NA_TABELA)
        //        );
        //    TreeViewItem treeViewItem;
        //    TreeViewItem treeViewItemParent = new TreeViewItem()
        //    {
        //        Header = $"{vw_tabela.NOME} ({vw_campoCollection.Count} Campos)",
        //        Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //        {
        //            RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia,
        //            NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Tabela,
        //            TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Editar,
        //            ID = vw_tabela.ID
        //        }
        //    };

        //    treeViewItemParent.Selected += TreeViewItem_Selected;


        //    foreach (var item in vw_campoCollection)
        //    {
        //        treeViewItem = new TreeViewItem()
        //        {
        //            Header = $"{item.NOME} ({item.MODELO_DE_DADOS__TIPO_PRIMITIVO_CAMPO__NOME_CSHARP})",
        //            Tag = new Flextech.Replicador.Wpf.Models.TagTreeView()
        //            {
        //                RaizDaTreeView = Models.TagTreeView.RaizDaTreeViewEnum.ModeloDePersistencia,
        //                NomeDoModelo = Models.TagTreeView.NomeDoModeloEnum.Campo,
        //                TipoDaTela = Models.TagTreeView.TipoDaTelaEnum.Editar,
        //                ID = item.ID
        //            }
        //        };

        //        treeViewItem.Selected += TreeViewItem_Selected;

        //        treeViewItemParent.Items.Add(treeViewItem);
        //    }

        //    return treeViewItemParent;
        //}

        #endregion Persistence Model

        #endregion Tree View

        //private void MostrarModeloDeDadosUserControls(Flextech.Replicador.Wpf.Models.TagTreeView tagTreeView)
        //{
        //    this.ModeloDeDadosViewModel.Atualizar(tagTreeView);
        //    this.ConteudoGrid.Children.Add(this.ModeloDeDadosViewModel.ModeloDeDadosListarUC);

        //    //this.ModeloDeDadosListarUC.DataContext = null;
        //    //this.ModeloDeDadosListarUC.DataContext = this.ModeloDeDadosViewModel;
        //}

        //private void ShowPersistenceModelUserControls(Flextech.Replicador.Wpf.Models.TagTreeView tagTreeView)
        //{

        //}
    }
}

