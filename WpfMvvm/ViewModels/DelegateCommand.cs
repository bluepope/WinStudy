﻿using System;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommand<T> : ICommand
    {
        Action<T> executeTargets = delegate { };
        Func<bool> canExecuteTargets = delegate { return false; };

        public bool CanExecute(object parameter)
        {
            var targets = canExecuteTargets.GetInvocationList();
            
            //기본 체크 바인딩을 안건 경우 일단 enable
            if (targets?.Length <= 1)
                return true;

            foreach (Func<bool> target in targets)
            {
                if (target.Invoke())
                    return true;
            }

            return false;
        }
        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == true)
                executeTargets(parameter != null ? (T)parameter : default(T));
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event Action<T> ExecuteTargets
        {
            add => executeTargets += value;
            remove => executeTargets -= value;
        }
        public event Func<bool> CanExecuteTargets
        {
            add => canExecuteTargets += value;
            remove => canExecuteTargets -= value;
        }
    }
}