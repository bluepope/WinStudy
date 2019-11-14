using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommandAsync : ICommand
    {
        public bool IsExecuting { get; private set; } = false;
        Func<Task> executeTargets;
        Func<bool> canExecuteTargets = delegate { return false; };

        public bool CanExecute(object parameter)
        {
            return !IsExecuting && (canExecuteTargets.GetInvocationList().Length == 1 || (canExecuteTargets?.Invoke() ?? true));
        }
        public async void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;

            IsExecuting = true;
            CommandManager.InvalidateRequerySuggested();

            await executeTargets();

            IsExecuting = false;
            SynchronizationContext.Current.Post((state) => 
            {
                CommandManager.InvalidateRequerySuggested();
            }, null);
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
        public event Func<Task> ExecuteTargets
        {
            add => executeTargets += value;
            remove => executeTargets -= value;
        }
    }
}