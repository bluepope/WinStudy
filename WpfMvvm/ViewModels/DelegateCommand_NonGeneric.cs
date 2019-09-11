using System;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public bool IsEnabled { get; set; } = true;
        Action executeTargets = delegate { };
        Func<bool> canExecuteTargets = delegate { return false; };

        public bool CanExecute(object parameter)
        {
            return IsEnabled && (canExecuteTargets.GetInvocationList().Length == 1 || (canExecuteTargets?.Invoke() ?? true));
        }
        public void Execute(object parameter)
        {
            executeTargets();
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public event Func<bool> CanExecuteTargets
        {
            add => canExecuteTargets += value;
            remove => canExecuteTargets -= value;
        }
        public event Action ExecuteTargets
        {
            add => executeTargets += value;
            remove => executeTargets -= value;
        }
    }
}