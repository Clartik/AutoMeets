using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoMeetsUI
{
	/// <summary>
	/// The View Model for the Help Screen
	/// </summary>
	public class HelpViewModel : BaseViewModel
	{
		#region Public Properties



		#endregion

		#region Commands

		public ICommand BackCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public HelpViewModel()
		{
			// Create Commands
			BackCommand = new RelayCommand(async () => await BackAsync());
		}

		#endregion

		#region Event Methods

		public async Task BackAsync()
		{
			// Close Help Page
			IoC.Application.HelpMenuVisible = false;

			await Task.Delay(1);
		}

		#endregion
	}
}
