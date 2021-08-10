﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTreeView
{

    public class RelayCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;


        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            _execute = ((_) => execute());
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        #region ICommand Interface
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
        #endregion
    }
}
