/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador.Wpf
Arquivo..........: Base\_ClasseFlextech1.cs
Espaço de nome...: Flextech.Replicador.Wpf.Base
Classe...........: _ClasseFlextech1
Descrição........: 
===============================================================================
Criação..........: 10/01/2019 - Lessandro Santana
Alteração........: 10/01/2019 - Lessandro Santana
===============================================================================
*/


namespace Flextech.Replicador.Wpf.Base
{
    public partial class ReplicadorViewModelBase : Flextech.Infra.Wpf.Base.ViewModelBase
    {
        #region Propriedades 

        public Flextech.Replicador.Repositorio.Repositorio Repositorio { get { return Flextech.Replicador.Estatico.Repositorio; } set { Flextech.Replicador.Estatico.Repositorio = value; } }

        #endregion Propriedades 

        #region Construtor

        public ReplicadorViewModelBase() : base()
        {
            base.ColecaoDeErros.Clear();
        }

        #endregion Construtor

    }
}