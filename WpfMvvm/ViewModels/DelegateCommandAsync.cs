using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

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
            SynchronizationContext.Current.Post((state) =>
            {
                CommandManager.InvalidateRequerySuggested();
            }, null);

            if (parameter?.GetType().Name == "SelectedItemCollection")
            {
                var list = (IList)parameter;
                var arr = new T[list.Count];

                ((IList)parameter).CopyTo(arr, 0);
                    
                foreach (var item in arr)
                {
                    await executeTargets((T)item);
                }
            }
            else
            {
                await executeTargets(parameter != null ? (T)parameter : default(T));
            }

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