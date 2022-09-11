using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows;
using Notification.Wpf;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace AutoMeetsUI
{
	/// <summary>
	/// The View Model for the Default Screen
	/// </summary>
	public class DefaultViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// This next class for the user
		/// </summary>
		public string NextClass { get; set; }

		/// <summary>
		/// This text will display whether the program is checking the Time or if it will launch class
		/// </summary>
		public string CheckingText { get; set; }

		/// <summary>
		/// This text will animate in and out to tell the user the app is still running
		/// </summary>
		public string AnimateCheckingText { get; set; }

		/// <summary>
		/// Text that talks about stuff like news, bugs, etc.
		/// </summary>
		public string NonsenseText { get; set; }

		public string ClassStartText { get; set; }

		/// <summary>
		/// A bool that will tell if it is time for class or not
		/// </summary>
		public bool TimeforClass { get; set; }

		public bool Scan { get; set; }

		public Visibility CheckingTimeVisibility { get; set; }

		public Visibility ClassTimeVisibility { get; set; }

		public Visibility AnimateDotVisibility { get; set; }

		List<int> Weekdays { get; set; } = new List<int>();

		List<int> FridaySet { get; set; } = new List<int>();

		public List<int> OddSet { get; set; } = new List<int>();
		public List<int> EvenSet { get; set; } = new List<int>();

		public bool AutomationFinished { get; set; }

		SettingsViewModel settings;
		SetupViewModel setup;

		public WeeklyData weeklyData;

		DateTime today;

		TimeSpan currentTime;

		public string CurrentClassName { get; set; }
		public string CurrentClassCode { get; set; }
		public bool CurrentClassIsCode { get; set; }

		/// <summary>
		/// The view model for the Setup Popup Menu Prompt
		/// </summary>
		public SundaySetupPopupMenuViewModel SetupMenu { get; set; }

		/// <summary>
		/// True to show the attachment menu, false to hide it
		/// </summary>
		public bool SetupMenuVisible { get; set; }

		public Visibility RefreshVisibility { get; set; } = Visibility.Collapsed;

		public bool RefreshIsRunning { get; set; }

		bool TempScanOn = false;

		public bool FridaySkip { get; set; }

		public DateTime DateToDeleteSettings { get; set; }

		public Visibility RefreshClassTimeVisibility { get; set; } = Visibility.Visible;

		public bool RefreshClassTimeIsRunning { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to open the Setup Page
		/// </summary>
		public ICommand SetupCommand { get; set; }

		/// <summary>
		/// The command to open the Settings Page
		/// </summary>
		public ICommand SettingsCommand { get; set; }

		/// <summary>
		/// The command to open the Help Page
		/// </summary>
		public ICommand HelpCommand { get; set; }

		public ICommand LaunchCommand { get; set; }

		public ICommand RefreshCommand { get; set; }
		public ICommand RefreshClassTimeCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public DefaultViewModel()
		{
			// Create Commands
			SetupCommand = new RelayCommand(async () => await SetupAsync());
			SettingsCommand = new RelayCommand(async () => await SettingsAsync());
			HelpCommand = new RelayCommand(async () => await HelpAsync());
			RefreshCommand = new RelayParameterizedCommand(async (parameter) => await RefreshValuesAsync(parameter));
			RefreshClassTimeCommand = new RelayParameterizedCommand(async (parameter) => await RefreshClassTimeValuesAsync(parameter));
			LaunchCommand = new RelayCommand(() => LaunchAsync());

			// Make a default menu
			SetupMenu = new SundaySetupPopupMenuViewModel();

			settings = IoC.Settings;
			setup = IoC.SetupPage;
			today = DateTime.Today;
			currentTime = DateTime.Now.TimeOfDay;

			try
			{
				weeklyData = SaveSystem.LoadWeekly();

				if (weeklyData != null)
					DateToDeleteSettings = weeklyData.DateToDelete;
			}
			catch {}

			if (today.CompareTo(DateToDeleteSettings) >= 0)
				SaveSystem.DeleteWeekly();

			CheckingTimeVisibility = Visibility.Visible;
			AnimateDotVisibility = Visibility.Collapsed;
			ClassTimeVisibility = Visibility.Collapsed;
			RefreshClassTimeVisibility = Visibility.Collapsed;

			Scan = true;
			CheckingText = "Checking Time";

			try
			{
				weeklyData = SaveSystem.LoadWeekly();

				if (weeklyData != null)
				{
					Weekdays = weeklyData.Weekdays;
					FridaySet = weeklyData.FridaySet;
					OddSet = weeklyData.OddSet;
					EvenSet = weeklyData.EvenSet;
					FridaySkip = weeklyData.FridaySkip;

					SetupMenuVisible = false;
					NextClassPredictor();
				}
				else if (weeklyData == null)
				{
					SetupMenuVisible = true;
						
					NextClass = "Classes Are Not Available To Load";
					CheckingText = "AutoMeets is Off";
					/*CheckingTimeVisibility = Visibility.Collapsed;
					RefreshVisibility = Visibility.Visible;*/
				}
			}
			catch {}

			// For Help Pics \/
			CheckingText = "Checking Time";
			AnimateDotVisibility = Visibility.Visible;
			NextClass = "Your Next Class is English at 8:30 AM";
			SetupMenuVisible = false;
		}

		#endregion

		#region Command Methods

		/*public void UpdateHelpText()
		{
			try
			{
				WebClient webClient = new WebClient();
				NonsenseText = webClient.DownloadString("https://drive.google.com/uc?export=download&id=1WZvXQbUJi1RaGtATzz2m3iEYeM1tezAA");
				Debug.WriteLine("Nonsense Text has been downloaded and set.");
			}
			catch
			{
				Debug.WriteLine("Nonsense Text had some trouble.");
				NonsenseText = "Not connected to the internet or the internet connection is weak. Please check your WiFi connection.";
			}
		}*/

		public void NextClassPredictor()
		{
			if (today.DayOfWeek >= DayOfWeek.Monday && today.DayOfWeek <= DayOfWeek.Friday)
			{
				if (!settings.DisableChecked)
				{
					if (setup.ZeroYesChecked)
					{
						if (Weekdays.Contains((int)today.DayOfWeek))
						{
							if (OddSet.Contains((int)today.DayOfWeek))
							{
								if (currentTime < new TimeSpan(7, 20 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 0, 00))
									NextClass = $"Your Next Class is {setup.Per0Name} at 7:20 AM";
								else if (currentTime < new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime > new TimeSpan(7, 20, 00))
								{
									if (!setup.Per1SkipChecked)
										NextClass = $"Your Next Class is {setup.Per1Name} at 8:30 AM";
									else
									{
										if (!setup.Per3SkipChecked)
											NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
										else
										{
											if (!setup.Per5SkipChecked)
												NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
											else
												NextClass = "No More Classes are Scheduled for the Rest of Today";
										}
									}
								}
								else if (currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime > new TimeSpan(8, 30, 00))
								{
									if (!setup.Per3SkipChecked)
										NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
									else
									{
										if (!setup.Per5SkipChecked)
											NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
										else
											NextClass = "No More Classes are Scheduled for the Rest of Today";
									}
								}
								else if (currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime > new TimeSpan(10, 25, 00))
								{
									if (!setup.Per5SkipChecked)
										NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
									else
										NextClass = "No More Classes are Scheduled for the Rest of Today";
								}
								else if (currentTime > new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(23, 59, 59))
									NextClass = "No More Classes are Scheduled for the Rest of Today";
							}
							else if (EvenSet.Contains((int)today.DayOfWeek))
							{
								if (currentTime < new TimeSpan(7, 20 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 0, 00))
									NextClass = $"Your Next Class is {setup.Per0Name} at 7:20 AM";
								else if (currentTime < new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 0, 00))
								{
									if (!setup.Per2SkipChecked)
										NextClass = $"Your Next Class is {setup.Per2Name} at 8:30 AM";
									else
									{
										if (!setup.Per4SkipChecked)
											NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
										else
										{
											if (!setup.Per6SkipChecked)
												NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
											else
												NextClass = "No More Classes are Scheduled for the Rest of Today";
										}
									}
								}
								else if (currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime > new TimeSpan(8, 30, 00))
								{
									if (!setup.Per4SkipChecked)
										NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
									else
									{
										if (!setup.Per6SkipChecked)
											NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
										else
											NextClass = "No More Classes are Scheduled for the Rest of Today";
									}
								}
								else if (currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime > new TimeSpan(10, 25, 00))
								{
									if (!setup.Per6SkipChecked)
										NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
									else
										NextClass = "No More Classes are Scheduled for the Rest of Today";
								}
								else if (currentTime > new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(23, 59, 59))
									NextClass = "No More Classes are Scheduled for the Rest of Today";
							}
						}
						else
							NextClass = "Classes Are Not Available To Load";
					}
					else
					{
						if (Weekdays.Contains((int)today.DayOfWeek))
						{
							if (OddSet.Contains((int)today.DayOfWeek))
							{
								if (currentTime < new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 00, 00))
								{
									if (!setup.Per1SkipChecked)
										NextClass = $"Your Next Class is {setup.Per1Name} at 8:30 AM";
									else
									{
										if (!setup.Per3SkipChecked)
											NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
										else
										{
											if (!setup.Per5SkipChecked)
												NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
											else
												NextClass = "No More Classes are Scheduled for the Rest of Today";
										}
									}
								}
								else if (currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime > new TimeSpan(8, 30, 00))
								{
									if (!setup.Per3SkipChecked)
										NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
									else
									{
										if (!setup.Per5SkipChecked)
											NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
										else
											NextClass = "No More Classes are Scheduled for the Rest of Today";
									}
								}
								else if (currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime > new TimeSpan(10, 25, 00))
								{
									if (!setup.Per5SkipChecked)
										NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
									else
										NextClass = "No More Classes are Scheduled for the Rest of Today";
								}
								else if (currentTime > new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(23, 59, 59))
									NextClass = "No More Classes are Scheduled for the Rest of Today";
							}
							else if (EvenSet.Contains((int)today.DayOfWeek))
							{
								if (currentTime < new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 0, 00))
								{
									if (!setup.Per2SkipChecked)
										NextClass = $"Your Next Class is {setup.Per2Name} at 8:30 AM";
									else
									{
										if (!setup.Per4SkipChecked)
											NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
										else
										{
											if (!setup.Per6SkipChecked)
												NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
											else
												NextClass = "No More Classes are Scheduled for the Rest of Today";
										}
									}
								}
								else if (currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime > new TimeSpan(8, 30, 00))
								{
									if (!setup.Per4SkipChecked)
										NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
									else
									{
										if (!setup.Per6SkipChecked)
											NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
										else
											NextClass = "No More Classes are Scheduled for the Rest of Today";
									}
								}
								else if (currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime > new TimeSpan(10, 25, 00))
								{
									if (!setup.Per6SkipChecked)
										NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
									else
										NextClass = "No More Classes are Scheduled for the Rest of Today";
								}
								else if (currentTime > new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(23, 59, 59))
									NextClass = "No More Classes are Scheduled for the Rest of Today";
							}
						}
						else
							NextClass = "Classes Are Not Available To Load";
					}

					if (FridaySet.Contains((int)today.DayOfWeek))
					{
						if (currentTime < new TimeSpan(9, 15 - settings.OffsetMin, 0) && currentTime > new TimeSpan(0, 0, 00))
						{
							if (!FridaySkip)
								NextClass = $"Your Next Class is {setup.FridayName} at 9:15 AM";
						}
						else if (currentTime > new TimeSpan(9, 15, 0))
							NextClass = "No More Classes are Scheduled for the Rest of Today";
					}
				}
				else
					NextClass = "AutoMeets is Disabled for Today";
			}
			else
				NextClass = "AutoMeets will not work on Weekends";
		}

		public async Task TimeScan()
		{
			if (today.DayOfWeek >= DayOfWeek.Monday && today.DayOfWeek <= DayOfWeek.Friday)
			{
				while (Scan)
				{
					if (!TempScanOn)
					{
						if (!settings.DisableChecked)
						{
							currentTime = DateTime.Now.TimeOfDay;

							if (setup.ZeroYesChecked)
							{
								if (Weekdays.Contains((int)today.DayOfWeek) && currentTime >= new TimeSpan(7, 19 - settings.OffsetMin, 59) && currentTime <= new TimeSpan(12, 51, 00))
								{
									if (currentTime > new TimeSpan(7, 20, 00) && currentTime < new TimeSpan(8, 30 - settings.OffsetMin, 00) || currentTime > new TimeSpan(8, 30, 00) && currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 00) || currentTime > new TimeSpan(10, 25, 00) && currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00))
										await Task.Delay(1000);
									else
									{
										if (OddSet.Contains((int)today.DayOfWeek))
										{
											if (currentTime >= new TimeSpan(7, 20 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 20, 00) && !AutomationFinished)
											{
												TempScanOn = true;
												await ClassTime(setup.Per0Name, setup.Per0Code, setup.Per0IsCode);
											}
											else if (currentTime >= new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 30, 00) && !AutomationFinished)
											{
												if (!setup.Per1SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per1Name, setup.Per1Code, setup.Per1IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime < new TimeSpan(10, 25, 00) && !AutomationFinished)
											{
												if (!setup.Per3SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per3Name, setup.Per3Code, setup.Per3IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime < new TimeSpan(12, 50, 00) && !AutomationFinished)
											{
												if (!setup.Per5SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per5Name, setup.Per5Code, setup.Per5IsCode);
												}
											}
											else
												await Task.Delay(1000);

											if (currentTime >= new TimeSpan(7, 20, 0) && currentTime < new TimeSpan(7, 21, 00) && AutomationFinished)
											{
												if (!setup.Per1SkipChecked)
													NextClass = $"Your Next Class is {setup.Per1Name} at 8:30 AM";
												else
												{
													if (!setup.Per3SkipChecked)
														NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
													else
													{
														if (!setup.Per5SkipChecked)
															NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
														else
															NextClass = "No More Classes are Scheduled for the Rest of Today";
													}
												}

												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(8, 30, 0) && currentTime < new TimeSpan(8, 31, 00) && AutomationFinished)
											{
												if (!setup.Per3SkipChecked)
													NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
												else
												{
													if (!setup.Per5SkipChecked)
														NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
													else
														NextClass = "No More Classes are Scheduled for the Rest of Today";
												}

												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(10, 25, 0) && currentTime < new TimeSpan(10, 26, 00) && AutomationFinished)
											{
												if (!setup.Per5SkipChecked)
													NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
												else
													NextClass = "No More Classes are Scheduled for the Rest of Today";

												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(12, 51, 00) && AutomationFinished)
											{
												NextClass = "No More Classes are Scheduled for the rest of Today";
												AutomationFinished = false;
											}
											else
												await Task.Delay(1000);
										}
										else if (EvenSet.Contains((int)today.DayOfWeek))
										{
											if (currentTime >= new TimeSpan(7, 20 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 20, 00) && !AutomationFinished)
											{
												TempScanOn = true;
												await ClassTime(setup.Per0Name, setup.Per0Code, setup.Per0IsCode);
											}
											else if (currentTime >= new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 30, 00) && !AutomationFinished)
											{
												if (!setup.Per2SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per2Name, setup.Per2Code, setup.Per2IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime < new TimeSpan(10, 25, 00) && !AutomationFinished)
											{
												if (!setup.Per4SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per4Name, setup.Per4Code, setup.Per4IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime < new TimeSpan(12, 50, 00) && !AutomationFinished)
											{
												if (!setup.Per6SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per6Name, setup.Per6Code, setup.Per6IsCode);
												}
											}
											else
												await Task.Delay(1000);

											if (currentTime >= new TimeSpan(7, 20, 0) && currentTime < new TimeSpan(7, 21, 00) && AutomationFinished)
											{
												if (!setup.Per2SkipChecked)
													NextClass = $"Your Next Class is {setup.Per2Name} at 8:30 AM";
												else
												{
													if (!setup.Per4SkipChecked)
														NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
													else
													{
														if (!setup.Per6SkipChecked)
															NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
														else
															NextClass = "No More Classes are Scheduled for the Rest of Today";
													}
												}
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(8, 30, 0) && currentTime < new TimeSpan(8, 31, 00) && AutomationFinished)
											{
												if (!setup.Per4SkipChecked)
													NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
												else
												{
													if (!setup.Per6SkipChecked)
														NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
													else
														NextClass = "No More Classes are Scheduled for the Rest of Today";
												}
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(10, 25, 0) && currentTime < new TimeSpan(10, 26, 00) && AutomationFinished)
											{
												if (!setup.Per6SkipChecked)
													NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
												else
													NextClass = "No More Classes are Scheduled for the Rest of Today";
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(12, 51, 00) && AutomationFinished)
											{
												NextClass = "No More Classes are Scheduled for the rest of Today";
												AutomationFinished = false;
											}
											else
												await Task.Delay(1000);
										}
										else
											await Task.Delay(1000);
									}
								}
								else
									await Task.Delay(1000);
							}
							else
							{
								if (Weekdays.Contains((int)today.DayOfWeek) && currentTime >= new TimeSpan(8, 29 - settings.OffsetMin, 59) && currentTime <= new TimeSpan(12, 51, 00))
								{
									if (currentTime > new TimeSpan(8, 30, 00) && currentTime < new TimeSpan(10, 25 - settings.OffsetMin, 00) || currentTime > new TimeSpan(10, 25, 00) && currentTime < new TimeSpan(12, 50 - settings.OffsetMin, 00))
										await Task.Delay(1000);
									else
									{
										if (OddSet.Contains((int)today.DayOfWeek))
										{
											if (currentTime >= new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 30, 00) && !AutomationFinished)
											{
												if (!setup.Per1SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per1Name, setup.Per1Code, setup.Per1IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime < new TimeSpan(10, 25, 00) && !AutomationFinished)
											{
												if (!setup.Per3SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per3Name, setup.Per3Code, setup.Per3IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime < new TimeSpan(12, 50, 00) && !AutomationFinished)
											{
												if (!setup.Per5SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per5Name, setup.Per5Code, setup.Per5IsCode);
												}
											}
											else
												await Task.Delay(1000);

											if (currentTime >= new TimeSpan(8, 30, 0) && currentTime < new TimeSpan(8, 31, 00) && AutomationFinished)
											{
												if (!setup.Per3SkipChecked)
													NextClass = $"Your Next Class is {setup.Per3Name} at 10:25 AM";
												else
												{
													if (!setup.Per5SkipChecked)
														NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
													else
														NextClass = "No More Classes are Scheduled for the Rest of Today";
												}
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(10, 25, 0) && currentTime < new TimeSpan(10, 26, 00) && AutomationFinished)
											{
												if (!setup.Per5SkipChecked)
													NextClass = $"Your Next Class is {setup.Per5Name} at 12:50 PM";
												else
													NextClass = "No More Classes are Scheduled for the Rest of Today";
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(12, 51, 00) && AutomationFinished)
											{
												NextClass = "No More Classes are Scheduled for the rest of Today";
												AutomationFinished = false;
											}
											else
												await Task.Delay(1000);
										}
										else if (EvenSet.Contains((int)today.DayOfWeek))
										{
											if (currentTime >= new TimeSpan(8, 30 - settings.OffsetMin, 0) && currentTime < new TimeSpan(8, 30, 00) && !AutomationFinished)
											{
												if (!setup.Per2SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per2Name, setup.Per2Code, setup.Per2IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(10, 25 - settings.OffsetMin, 0) && currentTime < new TimeSpan(10, 25, 00) && !AutomationFinished)
											{
												if (!setup.Per4SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per4Name, setup.Per4Code, setup.Per4IsCode);
												}
											}
											else if (currentTime >= new TimeSpan(12, 50 - settings.OffsetMin, 00) && currentTime < new TimeSpan(12, 50, 00) && !AutomationFinished)
											{
												if (!setup.Per6SkipChecked)
												{
													TempScanOn = true;
													await ClassTime(setup.Per6Name, setup.Per6Code, setup.Per6IsCode);
												}
											}
											else
												await Task.Delay(1000);

											if (currentTime >= new TimeSpan(8, 30, 0) && currentTime < new TimeSpan(8, 31, 00) && AutomationFinished)
											{
												if (!setup.Per4SkipChecked)
													NextClass = $"Your Next Class is {setup.Per4Name} at 10:25 AM";
												else
												{
													if (!setup.Per6SkipChecked)
														NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
													else
														NextClass = "No More Classes are Scheduled for the Rest of Today";
												}
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(10, 25, 0) && currentTime < new TimeSpan(10, 26, 00) && AutomationFinished)
											{
												if (!setup.Per6SkipChecked)
													NextClass = $"Your Next Class is {setup.Per6Name} at 12:50 PM";
												else
													NextClass = "No More Classes are Scheduled for the Rest of Today";
												AutomationFinished = false;
											}
											else if (currentTime >= new TimeSpan(12, 50, 00) && currentTime < new TimeSpan(12, 51, 00) && AutomationFinished)
											{
												NextClass = "No More Classes are Scheduled for the rest of Today";
												AutomationFinished = false;
											}
											else
												await Task.Delay(1000);
										}
										else
											await Task.Delay(1000);
									}
								}
								else
									await Task.Delay(1000);
							}

							if (FridaySet.Contains((int)today.DayOfWeek) && currentTime >= new TimeSpan(9, 14 - settings.OffsetMin, 00) && currentTime <= new TimeSpan(9, 16, 00))
							{
								if (currentTime >= new TimeSpan(9, 15 - settings.OffsetMin, 0) && currentTime < new TimeSpan(9, 15, 00) && !AutomationFinished)
								{
									if (!FridaySkip)
									{
										TempScanOn = true;
										await ClassTime(setup.FridayName, setup.FridayCode, setup.FridayIsCode);
									}
								}
								else if (currentTime >= new TimeSpan(9, 15, 0) && currentTime < new TimeSpan(9, 16, 00) && AutomationFinished)
								{
									NextClass = "No More Classes are Scheduled for the rest of Today";
									AutomationFinished = false;
								}
								else
									await Task.Delay(1000);
							}
							else
								await Task.Delay(1000);
						}
						else
							await Task.Delay(1000);
					}
					else
						await Task.Delay(1000);
				}
			}
		}

		public async Task ClassTime(string className, string classCode, bool classIsCode)
		{
			CurrentClassName = className;
			CurrentClassCode = classCode;
			CurrentClassIsCode = classIsCode;

			CheckingTimeVisibility = Visibility.Collapsed;
			ClassTimeVisibility = Visibility.Visible;

			ClassStartText = $"{className} is going to start soon.";
			NextClass = $"{className} is starting...";

			//var notificationManager = new NotificationManager();
			//notificationManager.Show("AutoMeets is Ready", $"{className} is about to start. Click on me to Launch AutoMeets.", NotificationType.Notification, expirationTime: TimeSpan.MaxValue, onClick: () => LaunchAsync());

			AutomationFinished = true;

			//await RefreshClassTimeValuesAsync(false);

			await Task.Delay(1);
		}

		public async Task SetupAsync()
		{
			// Open Setup Page
			IoC.Application.SetupMenuVisible = true;

			await Task.Delay(1);
		}

		public async Task SettingsAsync()
		{
			// Open Settings Page
			IoC.Application.SettingsMenuVisible = true;

			await Task.Delay(1);
		}

		public async Task HelpAsync()
		{
			// Open Help Page
			IoC.Application.HelpMenuVisible = true;

			await Task.Delay(1);
		}

		public async Task RefreshValuesAsync(object parameter)
		{
			await RunCommandAsync(() => RefreshIsRunning, async () =>
			{
				await Task.Delay(500);

				try
				{
					weeklyData = SaveSystem.LoadWeekly();

					if (weeklyData != null)
					{
						Weekdays = weeklyData.Weekdays;
						FridaySet = weeklyData.FridaySet;
						OddSet = weeklyData.OddSet;
						EvenSet = weeklyData.EvenSet;

						NextClassPredictor();
						CheckingText = "Checking Time";
						AnimateDotVisibility = Visibility.Visible;

						SetupMenuVisible = false;

						CheckingTimeVisibility = Visibility.Visible;
						RefreshVisibility = Visibility.Collapsed;
					}
				}
				catch { }
			});
		}
		
		public async Task RefreshClassTimeValuesAsync(object parameter)
		{
			await RunCommandAsync(() => RefreshClassTimeIsRunning, async () =>
			{
				await Task.Delay(500);
				CheckingTimeVisibility = Visibility.Collapsed;
				ClassTimeVisibility = Visibility.Visible;

				ClassStartText = $"{CurrentClassName} is going to start soon.";
				NextClass = $"{CurrentClassName} is starting...";
			});
		}

		public void LaunchAsync()
		{
			Clipboard.SetText(CurrentClassCode);

			if (CurrentClassIsCode)
			{
				var chromeDriverService = ChromeDriverService.CreateDefaultService("C:/Users/ygkar/Desktop");

				chromeDriverService.HideCommandPromptWindow = true;

				ChromeOptions options = new ChromeOptions();

				options.AddArgument("start-maximized");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Google Grid View.crx");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Visual Effects.crx");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Volume Master.crx");

				IWebDriver driver = new ChromeDriver(chromeDriverService, options);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

				driver.Url = "https://accounts.google.com/ServiceLogin?ltmpl=meet&continue=https%3A%2F%2Fmeet.google.com%3Fhs%3D193&";

				driver.FindElement(By.XPath("//*[@id='identifierId']")).SendKeys(setup.Email);
				driver.FindElement(By.XPath("//*[@id='identifierNext']")).Click();
				driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys(setup.Password);
				driver.FindElement(By.XPath("//*[@id='passwordNext']/div/button/div[2]")).Click();
				driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[2]/div[2]/div/c-wiz/div[1]/div/div/div[1]")).Click();

				driver.FindElement(By.XPath("//*[@id='yDmH0d']/div[3]/div/div[2]/span/div/div[2]/div[1]/div[1]/input")).SendKeys(CurrentClassCode);
				driver.FindElement(By.XPath("//*[@id='yDmH0d']/div[3]/div/div[2]/span/div/div[4]/div[2]/div/span/span")).Click();
			}
			else
			{
				var chromeDriverService = ChromeDriverService.CreateDefaultService("C:/Users/ygkar/Desktop");

				chromeDriverService.HideCommandPromptWindow = true;

				ChromeOptions options = new ChromeOptions();

				options.AddArgument("start-maximized");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Google Grid View.crx");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Visual Effects.crx");
				options.AddExtension($"{Directory.GetCurrentDirectory()}\\Extensions\\Volume Master.crx");

				IWebDriver driver = new ChromeDriver(chromeDriverService, options);
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

				driver.Url = "https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&ss=1&scc=1&ltmpl=default&ltmplcache=2&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";

				driver.FindElement(By.XPath("//*[@id='identifierId']")).SendKeys(setup.Email);
				driver.FindElement(By.XPath("//*[@id='identifierNext']")).Click();
				driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys(setup.Password);
				driver.FindElement(By.XPath("//*[@id='passwordNext']/div/button/div[2]")).Click();

				driver.Url = CurrentClassCode;
			}

			CurrentClassName = null;
			CurrentClassCode = null;
			CurrentClassIsCode = false;

			TempScanOn = false;

			ClassTimeVisibility = Visibility.Collapsed;
			CheckingTimeVisibility = Visibility.Visible;
		}

		#endregion
	}
}
