using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class DelegateCommand<T> : ICommand
    {
        public bool IsExecuting { get; private set; } = false;
        Action<T> executeTargets = delegate { };
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

            if (parameter?.GetType().Name == "SelectedItemCollection")
            {
                var list = (IList)parameter;
                var arr = new T[list.Count];

                ((IList)parameter).CopyTo(arr, 0);

                foreach (var item in arr)
                {
                    executeTargets((T)item);
                }
            }
            else
            {
                executeTargets(parameter != null ? (T)parameter : default(T));
            }
            

            IsExecuting = false;
            CommandManager.InvalidateRequerySuggested();
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