/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: NotificarPropriedadeBase.cs
Espaço de nome...: Flextech.Infra.Base
Classe...........: NotificarPropriedadeBase
Descrição........: Notificação automática das propriedades alteradas
==================================================================================
Criação..........: 04/08/2017 - Lessandro Santana
Alteração........: 18/01/2018 - Lessandro Santana
==================================================================================
*/

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Flextech.Infra.Base
{
    public abstract class NotificarPropriedadeBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public void NotifyPropertyChanging([CallerMemberName] String propertyName = "")
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
