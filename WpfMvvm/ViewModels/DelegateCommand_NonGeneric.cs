using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public bool IsExecuting { get; private set; } = false;
        Action executeTargets = delegate { };
        Func<bool> canExecuteTargets = delegate { return false; };

        public bool CanExecute(object parameter)
        {
            return !IsExecuting && (canExecuteTargets.GetInvocationList().Length == 1 || (canExecuteTargets?.Invoke() ?? true));
        }
        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;

            IsExecuting = true;
            CommandManager.InvalidateRequerySuggested();

            executeTargets();

            IsExecuting = false;
            CommandManager.InvalidateRequerySuggested();
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