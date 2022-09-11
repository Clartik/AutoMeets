using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace AutoMeetsUI
{
	/// <summary>
	/// The View Model for the Default Screen
	/// </summary>
	public class SettingsViewModel : BaseViewModel
	{
		#region Public Properties

		public int OffsetMin { get; set; } = 5;

		public int DisableDate { get; set; }

		public bool StartUpChecked { get; set; }

		public bool Item0Selected { get; set; }
		public bool Item1Selected { get; set; }
		public bool Item2Selected { get; set; }
		public bool Item3Selected { get; set; }
		public bool Item4Selected { get; set; }
		public bool Item5Selected { get; set; }
		public bool Item6Selected { get; set; }
		public bool Item7Selected { get; set; }
		public bool Item8Selected { get; set; }
		public bool Item9Selected { get; set; }
		public bool Item10Selected { get; set; }
		public bool Item11Selected { get; set; }
		public bool Item12Selected { get; set; }
		public bool Item13Selected { get; set; }
		public bool Item14Selected { get; set; }
		public bool Item15Selected { get; set; }

		/// <summary>
		/// A flag indicating if the save command is running
		/// </summary>
		public bool SaveIsRunning { get; set; }

		public bool DeleteIsRunning { get; set; }

		public bool DisableChecked { get; set; }

		public bool LightModeChecked { get; set; }
		public bool DarkModeChecked { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to exit out of the extra pages
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// The command to save everything
		/// </summary>
		public ICommand SaveCommand { get; set; }

		public ICommand DropDownCommand { get; set; }

		public ICommand StartupCommand { get; set; }

		public ICommand DisableCommand { get; set; }

		public ICommand LightModeCommand { get; set; }
		public ICommand DarkModeCommand { get; set; }
		
		public ICommand DeleteAllInfoCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SettingsViewModel()
		{
			// Create Commands
			BackCommand = new RelayCommand(async () => await BackAsync());
			SaveCommand = new RelayParameterizedCommand(async (parameter) => await SaveAsync(parameter));
			StartupCommand = new RelayCommand(async () => await StartupAsync());
			DisableCommand = new RelayCommand(() => DisableMethod());
			LightModeCommand = new RelayCommand(async () => await LightModeAsync());
			DarkModeCommand = new RelayCommand(async () => await DarkModeAsync());
			//DeleteAllInfoCommand = new RelayParameterizedCommand(async (parameter) => await DeleteAllInfoAsync(parameter));

			Item5Selected = true;

			LightModeChecked = true;
			DarkModeChecked = false;

			if (LightModeChecked)
				IoC.Application.SwitchBetweenLightorDark(true);

			try
			{
				SettingsData data = SaveSystem.LoadSettings();

				if (data != null)
				{
					OffsetMin = data.OffsetMin;
					StartUpChecked = data.StartUpChecked;
					LightModeChecked = data.LightModeChecked;
					DarkModeChecked = data.DarkModeChecked;

					if (LightModeChecked)
						IoC.Application.SwitchBetweenLightorDark(true);
					else if (DarkModeChecked)
						IoC.Application.SwitchBetweenLightorDark(false);

					if (OffsetMin == 0)
						Item0Selected = true;
					else if (OffsetMin == 1)
						Item1Selected = true;
					else if (OffsetMin == 2)
						Item2Selected = true;
					else if (OffsetMin == 3)
						Item3Selected = true;
					else if (OffsetMin == 4)
						Item4Selected = true;
					else if (OffsetMin == 5)
						Item5Selected = true;
					else if (OffsetMin == 6)
						Item6Selected = true;
					else if (OffsetMin == 7)
						Item7Selected = true;
					else if (OffsetMin == 8)
						Item8Selected = true;
					else if (OffsetMin == 9)
						Item9Selected = true;
					else if (OffsetMin == 10)
						Item10Selected = true;
					else if (OffsetMin == 11)
						Item11Selected = true;
					else if (OffsetMin == 12)
						Item12Selected = true;
					else if (OffsetMin == 13)
						Item13Selected = true;
					else if (OffsetMin == 14)
						Item14Selected = true;
					else if (OffsetMin == 15)
						Item15Selected = true;
				}
			}
			catch {}

			try
			{
				DisableData data = SaveSystem.LoadDisable();

				if (data != null)
				{
					DisableDate = data.DisableDate;

					if (DisableDate == DateTime.Today.Day)
						DisableChecked = true;
					else
						SaveSystem.DeleteDisable();
				}
			}
			catch {}
		}

		#endregion

		public async Task LightModeAsync()
		{
			if (LightModeChecked)
			{
				if (DarkModeChecked)
					DarkModeChecked = false;

				if (!IoC.Application.LightorDarkMode)
					IoC.Application.SwitchBetweenLightorDark(true);
			}
			
			await Task.Delay(1);
		}

		public async Task DarkModeAsync()
		{
			if (DarkModeChecked)
			{
				if (LightModeChecked)
					LightModeChecked = false;

				if (IoC.Application.LightorDarkMode)
					IoC.Application.SwitchBetweenLightorDark(false);
			}

			await Task.Delay(1);
		}

		public void DisableMethod()
		{
			if (DisableChecked)
			{
				DisableDate = DateTime.Today.Day;

				SaveSystem.SaveDisable(this);
			}
			else if(!DisableChecked)
			{
				SaveSystem.DeleteDisable();
			}
		}

		/*public async Task DeleteAllInfoAsync(object parameter)
		{
			await RunCommandAsync(() => DeleteIsRunning, async () =>
			{
				MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all of your personal information from this PC? You cannot undo this action.", "Delete All Personal Information?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);

				if (result == MessageBoxResult.Yes)
				{
					SaveSystem.DeleteInfo();
					SaveSystem.DeleteSchedule();
					SaveSystem.DeleteWeekly();
					SaveSystem.DeleteSettings();
					SaveSystem.DeleteDisable();

					await Task.Delay(1000);

					MessageBox.Show("All Personal Information that has been saved locally on your PC has been deleted.", "Personal Information Deleted", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

					DefaultViewModel defaultView = new DefaultViewModel();
					defaultView.NextClassPredictor();
				}
			});
		}*/

		/// <summary>
		/// Takes the user back to the base page
		/// </summary>
		/// <returns></returns>
		public async Task BackAsync()
		{
			try
			{
				SettingsData data = SaveSystem.LoadSettings();

				if (data != null)
				{
					if (OffsetMin != data.OffsetMin || StartUpChecked != data.StartUpChecked || LightModeChecked != data.LightModeChecked || DarkModeChecked != data.DarkModeChecked)
					{
						MessageBoxResult result = MessageBox.Show("Do you want to Save the Changes you made?", "Changes Have Been Made", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

						if (result == MessageBoxResult.Yes)
							await SaveAsync(false);
					}
				}
				else if (data == null)
				{
					if (OffsetMin != 5 || StartUpChecked != false || LightModeChecked || !DarkModeChecked)
					{
						MessageBoxResult result = MessageBox.Show("Do you want to Save the Changes you made?", "Changes Have Been Made", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

						if (result == MessageBoxResult.Yes)
							await SaveAsync(false);
					}
				}
			}
			catch {}

			// Exit Settings Page
			IoC.Application.SettingsMenuVisible = false;

			await Task.Delay(1);
		}

		/// <summary>
		/// Saves all the settings
		/// </summary>
		/// <returns></returns>
		public async Task SaveAsync(object parameter)
		{
			await RunCommandAsync(() => SaveIsRunning, async () =>
			{
				if (Item0Selected)
					OffsetMin = 0;
				else if (Item1Selected)
					OffsetMin = 1;
				else if (Item2Selected)
					OffsetMin = 2;
				else if (Item3Selected)
					OffsetMin = 3;
				else if (Item4Selected)
					OffsetMin = 4;
				else if (Item5Selected)
					OffsetMin = 5;
				else if (Item6Selected)
					OffsetMin = 6;
				else if (Item7Selected)
					OffsetMin = 7;
				else if (Item8Selected)
					OffsetMin = 8;
				else if (Item9Selected)
					OffsetMin = 9;
				else if (Item10Selected)
					OffsetMin = 10;
				else if (Item11Selected)
					OffsetMin = 11;
				else if (Item12Selected)
					OffsetMin = 12;
				else if (Item13Selected)
					OffsetMin = 13;
				else if (Item14Selected)
					OffsetMin = 14;
				else if (Item15Selected)
					OffsetMin = 15;

				SaveSystem.SaveSettings(this);

				await Task.Delay(1000);
			});
		}

		public async Task StartupAsync()
		{
			string startupFolderPath = @"%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup\";
			startupFolderPath = Environment.ExpandEnvironmentVariables(startupFolderPath);
			string shortcutPath = Path.GetFullPath(Path.Combine(startupFolderPath, "AutoMeets.LNK"));

			if (StartUpChecked)
			{
				string oldStartupPath = Path.GetFullPath(Path.Combine(startupFolderPath, "AutoMeetsStartup.LNK"));

				string currentPath = Directory.GetCurrentDirectory();
				string rootPath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\"));
				string exeTargetPath = Path.GetFullPath(Path.Combine(rootPath, "AutoMeetsLauncher.exe"));
				string oldShortcutPath = Path.GetFullPath(Path.Combine(rootPath, "AutoMeetsStartup.bat"));
				string workingDir = rootPath.Remove(rootPath.Length - 1, 1);

				if (File.Exists(oldStartupPath))
				{
					File.Delete(oldStartupPath);
					File.Delete(oldShortcutPath);
					//MessageBox.Show("Deleting", "Bye", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
				}

				if (File.Exists(shortcutPath))
					return;
				else
				{
					CreateShortcutClass.CreateShortcut("AutoMeets", rootPath, exeTargetPath, workingDir, "The Startup Utility to Launch AutoMeets at System Boot Up");
					MessageBox.Show("AutoMeets will now start up with the boot up of your computer.", "AutoMeets Will Now Launch at Bootup", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
				}
			}
			else
			{
				if (File.Exists(shortcutPath))
				{
					File.Delete(shortcutPath);
					MessageBox.Show("AutoMeets will no longer start up with the boot up of your computer.", "AutoMeets Will Not Launch at Bootup", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
				}
			}

			await Task.Delay(1);
		}
	}
}
