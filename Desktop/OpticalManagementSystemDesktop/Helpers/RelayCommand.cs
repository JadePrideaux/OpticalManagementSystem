using System.Windows.Input;

namespace OpticalManagementSystemDesktop.Helpers
{
    // Helper class to help writting ViewModel commands
    public class RelayCommand : ICommand
    {
        // Action i.e. button click - when to run the command
        private readonly Action<object?> _execute;
        // A function to see if the command can run, if null can always run.
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

