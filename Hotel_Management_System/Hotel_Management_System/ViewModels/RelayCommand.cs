using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel_Management_System.ViewModels
{
    public class RelayCommand : ICommand
    {
        //Field
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        // Ham Khoi Tao
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = null;
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExcute)
        {
            _execute = execute;
            _canExecute = canExcute;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Phuong thuc


        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
    }
}