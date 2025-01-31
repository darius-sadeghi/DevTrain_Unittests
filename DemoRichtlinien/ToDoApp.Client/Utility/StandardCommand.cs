using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoApp.Client.Utility
{
    public class StandardCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute = null;
        private ICommandOnCanExecute _canExecute = null;

        public StandardCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        public StandardCommand(ICommandOnExecute onExecuteMethod)
        {
            _execute = onExecuteMethod;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute.Invoke(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        #endregion

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
