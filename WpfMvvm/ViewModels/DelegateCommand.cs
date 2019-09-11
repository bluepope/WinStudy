using System;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommand<T> : ICommand
    {
        public bool IsEnabled { get; set; } = true;
        Action<T> executeTargets = delegate { };
        Func<bool> canExecuteTargets = delegate { return false; };

        public bool CanExecute(object parameter)
        {
            return IsEnabled && (canExecuteTargets.GetInvocationList().Length == 1 || (canExecuteTargets?.Invoke() ?? true));
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