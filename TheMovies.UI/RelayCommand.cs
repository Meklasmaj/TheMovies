using System;
using System.Windows.Input;

namespace TheMovies.UI
{
    /// <summary>
    /// RelayCommand implementerer WPF's ICommand-interface
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;          // Action er en delegate, der i dette tilfælde tager ét object som parameter og ikke returnerer noget
        private readonly Func<object?, bool>? _canExecute;  // Func er også en delegate og minder om forrige linje, men her bliver der returneret en bool

        public event EventHandler? CanExecuteChanged;       // Fortæller WPF, at den skal kontrollere CanExecute igen

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Hvis vi ikke har nogle regler, må command gerne køres.
        /// Findes der en regel, så spørg reglen først, om command må køres.
        /// </summary>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Dette er selve kommandoens handling - fx kan WPF sige "Udfør denne specifikke command", hvor RelayCommand kalder metoden
        /// uden at vide, hvad metoden præcis gør.
        /// </summary>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Fortæller WPF, at CanExecute skal kontrolleres igen
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}