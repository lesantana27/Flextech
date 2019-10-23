/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: ObjetoObservavelBase.cs
Espaço de nome...: Flextech.Infra.Base
Classe...........: ObjetoObservavelBase
Descrição........: Classe base de objeto observável
==================================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 18/01/2018 - Lessandro Santana
==================================================================================
*/

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Flextech.Infra.Base
{
    public abstract class ObjetoObservavelBase : Flextech.Infra.Base.NotificarPropriedadeBase
    {
        protected virtual bool ColocarNoCampo<T>(ref T campo, T valor, [CallerMemberName] string nomeDaPropriedade = null)
        {
            if (EqualityComparer<T>.Default.Equals(campo, valor)) return false;
            campo = valor;
            NotifyPropertyChanged(nomeDaPropriedade);
            return true;
        }
    }
}
