using System.Windows.Input;

namespace VNotes.Commands
{
    //try mvvm community toolkit
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public Action<object> _Execute { get; set; }
        public Predicate<object>? _CanExecute { get; set; }

        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (_CanExecute == null) return true;
            
            return _CanExecute(parameter!);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter!);
        }
    }
}
