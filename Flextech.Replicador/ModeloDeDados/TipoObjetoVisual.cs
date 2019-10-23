/*
===============================================================================
Solução..........: Flextech
Projeto..........: Replicador
Arquivo..........: ModeloDeDados\TipoObjetoVisual.cs
Espaço de nome...: Flextech.Replicador.ModeloDeDados
Classe...........: TipoObjetoVisual
Descrição........: Tipos de objetos visuais do replicador
===============================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 08/01/2019 - Lessandro Santana
===============================================================================
*/


using System.Runtime.Serialization;

namespace Flextech.Replicador.ModeloDeDados
{
    [DataContract]
    public partial class TipoObjetoVisual : Flextech.Replicador.Base.ModeloDeDadosBase
    {
        [DataMember]
        public string NomeDoTipo { get { return this._NomeDoTipo; } set { ColocarNoCampo(ref this._NomeDoTipo, value); } }
        private string _NomeDoTipo = "Não definido";

    }
}

//TYPE_NAME]		
//SHOW]			
//EDIT]			
//SHOW_WEB]		
//EDIT_WEB]		
//SHOW_WPF]		
//EDIT_WPF]		
//SHOW_XAMARIN]	
//EDIT_XAMARIN]	
