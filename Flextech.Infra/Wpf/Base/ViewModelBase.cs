/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Wpf\Base\WpfViewModelBase.cs
Espaço de nome...: Flextech.Infra.Wpf.Base
Classe...........: WpfViewModelBase
Descrição........: Classe base para implementação do ViewModel em WPF
==================================================================================
Criação..........: 19/12/2017 - Lessandro Santana
Alteração........: 19/12/2017 - Lessandro Santana
==================================================================================
*/

namespace Flextech.Infra.Wpf.Base
{
    public abstract class ViewModelBase : Flextech.Infra.Base.ObjetoBase
    {
        #region Propriedades

        public string NomeDaTela { get { return this._NomeDaTela; } set { ColocarNoCampo(ref this._NomeDaTela, value); } }
        private string _NomeDaTela;

        #endregion Propriedades

        #region Construtor

        public ViewModelBase()
        {

        }

        #endregion Construtor

        #region Métodos Privados
        #endregion Métodos Privados

        #region Métodos Protegidos

        protected virtual void Inicializar()
        {
            throw new System.NotImplementedException();
        }

        #endregion Métodos Protegidos

        #region Métodos Públicos

        #endregion Métodos Públicos
    }
}
