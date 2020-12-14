using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAD.AfspraakBeheer.Common
{
	public class RelayCommand : ICommand
	{
		readonly Action<Object> _executeMethod;
		readonly Func<Object, Boolean> _canExecuteMethod;

		public RelayCommand(Action<Object> executeMethod)
			: this(executeMethod, null)
		{ }
		public RelayCommand(Action<Object> executeMethod, Func<Object, Boolean> canExecuteMethod)
		{
			if (executeMethod == null)
				throw new NullReferenceException("executeMethod is required.");
			_executeMethod = executeMethod;
			_canExecuteMethod = canExecuteMethod;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecuteMethod == null ? true : _canExecuteMethod(parameter);
		}

		public void Execute(object parameter)
		{
			_executeMethod(parameter);
		}
	}
}
