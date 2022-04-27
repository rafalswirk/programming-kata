using System;
using System.Windows.Input;

namespace ICommandDemo.MVVM
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Predicate<object?> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object?> execute)
            :this(execute, null)
        {
        }

        public bool CanExecute(object? parameter)
        {
            if(canExecute == null)
                return true;
            return canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            if(execute == null)
                return;
            execute.Invoke(parameter);
        }
    }
}