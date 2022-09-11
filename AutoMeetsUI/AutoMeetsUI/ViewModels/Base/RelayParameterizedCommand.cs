using System;
using System.Windows.Input;

namespace AutoMeetsUI
{
	/// <summary>
	/// A base command that runs an Acton
	/// </summary>
	public class RelayParameterizedCommand : ICommand
	{
		#region Private Members

		/// <summary>
		/// The action to run
		/// </summary>
		private Action<object> mAction;

		#endregion

		#region Public Events

		/// <summary>
		/// The event that's fired when the <see cref="CanExecuteChanged"/> value has changed
		/// </summary>
		public event EventHandler CanExecuteChanged = (sender, e) => { };

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public RelayParameterizedCommand(Action<object> action)
		{
			mAction = action;
		}

		#endregion

		#region Command Methods

		/// <summary>
		/// A relay command can always execute
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter) { return true; }

		/// <summary>
		/// Executes the commands Action
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			mAction(parameter);
		}

		#endregion
	}
}
