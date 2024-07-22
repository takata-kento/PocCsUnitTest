using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWPF.ViewModels
{
    public class ForwardedCommand : ICommand
    {
        private Action action;
        private Func<bool> canExecute;
        public ForwardedCommand(Action a) : this(a, () => true) { }
        public ForwardedCommand(Action a, Func<bool> cx)
        {
            action = a;
            canExecute = cx;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
#pragma warning disable CS8767
        public bool CanExecute(object parameter)
#pragma warning restore CS8767
        {
            return canExecute();
        }
#pragma warning disable CS8767
        public void Execute(object parmeter)
#pragma warning restore CS8767
        {
            action();
        }
    }

    // Parameter 付き Command
    public class ForwardedCommand<T> : ICommand
    {
        private Action<T> action;
        private Func<bool> canExecute;
        public ForwardedCommand(Action<T> a) : this(a, () => true) { }

        public ForwardedCommand(Action<T> a, Func<bool> cx)
        {
            action = a;
            canExecute = cx;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

#pragma warning disable CS8767
        public bool CanExecute(object parameter)
#pragma warning restore CS8767
        {
            return canExecute();
        }

#pragma warning disable CS8767
        public void Execute(object parameter)
#pragma warning restore CS8767
        {
            action((T)parameter);
        }
    }
}
