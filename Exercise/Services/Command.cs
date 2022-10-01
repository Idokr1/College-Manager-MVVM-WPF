using System;
using System.Windows.Input;

namespace Exercise.Services
{
    internal class Command : ICommand
    {
        private Action action;
        public Command(Action action)
        {
            this.action = action;
        }
        
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action?.Invoke();
    }
}
