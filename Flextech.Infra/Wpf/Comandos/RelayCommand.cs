/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Wpf\Comandos\RelayCommand.cs
Espaço de nome...: Flextech.Infra.Wpf.Comandos
Classe...........: RelayCommand
Descrição........: Implementação da classe Relay command
==================================================================================
Criação..........: 19/12/2017 - Lessandro Santana
Alteração........: 19/12/2017 - Lessandro Santana
==================================================================================
*/


/* #################################
 * Exemplo de command SEM parametros
 * #################################
 * 
 * ViewModel
 *      public ICommand aaaCommand
 *      {
 *          get { if (null == _aaaCommand) _aaaCommand = new RelayCommand(ExecuteAAA); return _aaaCommand; }
 *      }
 *      private RelayCommand _aaaCommand;
 *      
 *      private void ExecuteNoParameterCommand(object naoUsado = null)
 *      {
 *          // código do comando aqui 
 *      }
 * 
 * View
 *      <Button Command="{Binding Path=NoParameterCommand}"/>
 * 
 * 
 * 
 * 
 * #################################
 * Exemplo de command COM parametros
 * ##################################
 * 
 * ViewModel
 *      public enum Fruit
 *      {
 *          Apple,
 *          Banana,
 *          Cantaloupe,
 *      }
 *      
 *      private RelayCommand<Fruit> _fruitParameterCommand;
 *      public ICommand FruitParameterCommand
 *      {
 *          get { if (null == _fruitParameterCommand) _fruitParameterCommand = new RelayCommand<Fruit>(ExecuteFruitParameterCommand); return _fruitParameterCommand; }
 *      }
 *      
 *      private void ExecuteFruitParameterCommand(Fruit fruit)
 *      {
 *          // código do comando aqui 
 *      }
 * 
 * View
 *      <Button Command="{Binding Path=FruitParameterCommand}" CommandParameter="{x:Static local:Fruit.Banana}"/>
 * 
 */




using System;
using System.Windows.Input;

namespace Flextech.Infra.Wpf.Comandos
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute) : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        #endregion

        #region Construtors

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion


    }
}
