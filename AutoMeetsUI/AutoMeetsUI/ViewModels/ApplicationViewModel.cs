using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AutoMeetsUI
{
	/// <summary>
	/// The application state as a view model
	/// </summary>
	public class ApplicationViewModel : BaseViewModel
	{
		/// <summary>
		/// The current page of the Application
		/// </summary>
		public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Default;

		/// <summary>
		/// True if the settings menu should be shown
		/// </summary>
		public bool SettingsMenuVisible { get; set; }

		/// <summary>
		/// True if the setup menu should be shown
		/// </summary>
		public bool SetupMenuVisible { get; set; }

		/// <summary>
		/// True if the help menu should be shown
		/// </summary>
		public bool HelpMenuVisible { get; set; }

		public Visibility MainWindowLightVisibility { get; set; }

		public Visibility MainWindowDarkVisibility { get; set; }

		public bool LightorDarkMode { get; set; }

		/// <summary>
		/// Navigates to the specified page
		/// </summary>
		/// <param name="page">The page to go to</param>
		public void GoToPage(ApplicationPage page)
		{
			// Set the current page
			CurrentPage = page;
		}

		public void SwitchBetweenLightorDark(bool lightordark)
		{
			LightorDarkMode = lightordark;

			if (LightorDarkMode)
			{
				MainWindowLightVisibility = Visibility.Visible;
				MainWindowDarkVisibility = Visibility.Collapsed;
			}
			else
			{
				MainWindowLightVisibility = Visibility.Collapsed;
				MainWindowDarkVisibility = Visibility.Visible;
			}
		}
	}
}
