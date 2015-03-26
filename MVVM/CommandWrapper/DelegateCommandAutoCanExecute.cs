using System;
using System.Linq;
using System.Windows.Input;

namespace Telerik.Windows.Controls
{
    public class DelegateCommandAutoCanExecute : ICommand
    {
        public ICommand WrappedCommand { get; private set; }
        /// <summary>
        /// Delegate Command auto can Execute
        /// </summary>
        /// <param name="commandToWrap">Pass the Delegate Command with Function and Can auto Execute Function</param>
        public DelegateCommandAutoCanExecute(ICommand commandToWrap)
        {
            if(commandToWrap==null)
            {
                throw new ArgumentNullException("commandToWrap","Command should not be null");
            }
            WrappedCommand=commandToWrap;
        }

        public void Execute(object parameter)
        {
            WrappedCommand.Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return WrappedCommand.CanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}