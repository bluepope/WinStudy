using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    public class DelegateCommandAsync<T> : ICommand
    {
        public bool IsExecuting { get; private set; } = false;
        Func<T, Task> executeTargets;
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

            await executeTargets(parameter != null ? (T)parameter : default(T));

            IsExecuting = false;
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                CommandManager.InvalidateRequerySuggested();
            });
            
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event Func<T, Task> ExecuteTargets
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