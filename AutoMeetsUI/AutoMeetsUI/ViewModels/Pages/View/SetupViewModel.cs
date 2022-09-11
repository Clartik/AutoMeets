
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace AutoMeetsUI
{
	/// <summary>
	/// A View Model for the Setup Page
	/// </summary>
	public class SetupViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The school email of the user
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The school password of the user
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// The confirmation password of the user
		/// </summary>
		public string ConfirmPassword { get; set; }

		#region Period 0

		public string Per0Name { get; set; }

		public string Per0Code { get; set; }

		public bool Per0IsCode { get; set; }

		#endregion

		#region Period 1

		/// <summary>
		/// Name of the user's Period 1 Class
		/// </summary>
		public string Per1Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 1 Class
		/// </summary>
		public string Per1Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 1
		/// </summary>
		public bool Per1IsCode { get; set; }

		#endregion

		#region Period 2

		/// <summary>
		/// Name of the user's Period 2 Class
		/// </summary>
		public string Per2Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 2 Class
		/// </summary>
		public string Per2Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 2
		/// </summary>
		public bool Per2IsCode { get; set; }

		#endregion

		#region Period 3

		/// <summary>
		/// Name of the user's Period 3 Class
		/// </summary>
		public string Per3Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 3 Class
		/// </summary>
		public string Per3Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 3
		/// </summary>
		public bool Per3IsCode { get; set; }

		#endregion

		#region Period 4

		/// <summary>
		/// Name of the user's Period 4 Class
		/// </summary>
		public string Per4Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 4 Class
		/// </summary>
		public string Per4Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 4
		/// </summary>
		public bool Per4IsCode { get; set; }

		#endregion

		#region Period 5

		/// <summary>
		/// Name of the user's Period 5 Class
		/// </summary>
		public string Per5Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 5 Class
		/// </summary>
		public string Per5Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 5
		/// </summary>
		public bool Per5IsCode { get; set; }

		#endregion

		#region Period 6

		/// <summary>
		/// Name of the user's Period 6 Class
		/// </summary>
		public string Per6Name { get; set; }

		/// <summary>
		/// Meet Code of the user's Period 6 Class
		/// </summary>
		public string Per6Code { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Period 6
		/// </summary>
		public bool Per6IsCode { get; set; }

		#endregion

		/// <summary>
		/// A bool to check if the Odd Toggle Button is selected or not
		/// </summary>
		public bool OddChecked { get; set; }

		/// <summary>
		/// A bool to check if the Even Toggle Button is selected or not
		/// </summary>
		public bool EvenChecked { get; set; }

		/// <summary>
		/// A bool to check if the Monday Toggle Button is selected or not
		/// </summary>
		public bool MondayChecked { get; set; }
		public bool MondayEnabled { get; set; } = true;

		/// <summary>
		/// A bool to check if the Tuesday Toggle Button is selected or not
		/// </summary>
		public bool TuesdayChecked { get; set; }
		public bool TuesdayEnabled { get; set; } = true;

		/// <summary>
		/// A bool to check if the Wednesday Toggle Button is selected or not
		/// </summary>
		public bool WednesdayChecked { get; set; }
		public bool WednesdayEnabled { get; set; } = true;

		/// <summary>
		/// A bool to check if the Thursday Toggle Button is selected or not
		/// </summary>
		public bool ThursdayChecked { get; set; }
		public bool ThursdayEnabled { get; set; } = true;

		/// <summary>
		/// A bool to check if the Friday Toggle Button is selected or not
		/// </summary>
		public bool FridayChecked { get; set; }
		public bool FridayEnabled { get; set; } = true;

		/// <summary>
		/// A bool to check if the Friday Period 1 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer1Checked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Period 2 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer2Checked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Period 3 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer3Checked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Period 4 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer4Checked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Period 5 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer5Checked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Period 6 Toggle Button is selected or not
		/// </summary>
		public bool FridayPer6Checked { get; set; }

		public List<int> Weekdays { get; set; } = new List<int>();

		public List<int> FridaySet { get; set; } = new List<int>();

		public List<int> OddSet { get; set; } = new List<int>();
		public List<int> EvenSet { get; set; } = new List<int>();

		#region Friday

		/// <summary>
		/// Name of the user's Friday Class
		/// </summary>
		public string FridayName { get; set; }

		/// <summary>
		/// Meet Code of the user's Friday Class
		/// </summary>
		public string FridayCode { get; set; }

		/// <summary>
		/// A bool to figure out if the code provided is a code or a link for Friday
		/// </summary>
		public bool FridayIsCode { get; set; }

		/// <summary>
		/// An int to figure out which period is linked with Friday
		/// </summary>
		public int FridayIsWhatPeriod { get; set; }

		#endregion

		public bool ZeroYesChecked { get; set; } = false;
		public bool ZeroNoChecked { get; set; } = true;

		public Visibility InfoVisibility { get; set; }

		public Visibility LeftPeriodVisibility { get; set; }

		public Visibility RightPeriodVisibility { get; set; }

		public Visibility FridayVisibility { get; set; }

		public Visibility WeekVisibility { get; set; }

		public Visibility SaturdayWeeklyVisibility { get; set; } = Visibility.Collapsed;

		public Visibility Per0Visibility { get; set; } = Visibility.Collapsed;

		public Visibility Per1MainVisibility { get; set; } = Visibility.Visible;
		public Visibility Per2MainVisibility { get; set; } = Visibility.Visible;
		public Visibility Per3MainVisibility { get; set; } = Visibility.Visible;
		public Visibility Per4MainVisibility { get; set; } = Visibility.Visible;
		public Visibility Per5MainVisibility { get; set; } = Visibility.Visible;
		public Visibility Per6MainVisibility { get; set; } = Visibility.Visible;

		public bool Per1SkipChecked { get; set; }
		public bool Per2SkipChecked { get; set; }
		public bool Per3SkipChecked { get; set; }
		public bool Per4SkipChecked { get; set; }
		public bool Per5SkipChecked { get; set; }
		public bool Per6SkipChecked { get; set; }

		public bool FridaySkip { get; set; }

		public bool SaveIsRunning { get; set; }

		DateTime Today { get; set; }

		public DateTime DateForSetupToDelete { get; set; }

		#endregion

		#region Public Commands

		/// <summary>
		/// Command to go back to the main page
		/// </summary>
		public ICommand BackCommand { get; set; }

		/// <summary>
		/// Command to save everything in the setup page
		/// </summary>
		public ICommand SaveCommand { get; set; }

		public ICommand OddCommand { get; set; }

		public ICommand EvenCommand { get; set; }

		public ICommand FridayPer1Command { get; set; }

		public ICommand FridayPer2Command { get; set; }

		public ICommand FridayPer3Command { get; set; }

		public ICommand FridayPer4Command { get; set; }

		public ICommand FridayPer5Command { get; set; }

		public ICommand FridayPer6Command { get; set; }

		public ICommand FridayCommand { get; set; }

		public ICommand ZeroYesCommand { get; set; }
		public ICommand ZeroNoCommand { get; set; }

		public ICommand Per1SkipCommand { get; set; }
		public ICommand Per2SkipCommand { get; set; }
		public ICommand Per3SkipCommand { get; set; }
		public ICommand Per4SkipCommand { get; set; }
		public ICommand Per5SkipCommand { get; set; }
		public ICommand Per6SkipCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SetupViewModel()
		{
			BackCommand = new RelayCommand(async () => await BackAsync());
			SaveCommand = new RelayParameterizedCommand(async (parameter) => await SaveAsync(parameter));
			OddCommand = new RelayCommand(() => Odd());
			EvenCommand = new RelayCommand(() => Even());
			FridayCommand = new RelayCommand(async () => await FridayAsync());

			FridayPer1Command = new RelayCommand(async() => await FridayPer1Async());
			FridayPer2Command = new RelayCommand(async() => await FridayPer2Async());
			FridayPer3Command = new RelayCommand(async() => await FridayPer3Async());
			FridayPer4Command = new RelayCommand(async() => await FridayPer4Async());
			FridayPer5Command = new RelayCommand(async() => await FridayPer5Async());
			FridayPer6Command = new RelayCommand(async() => await FridayPer6Async());
			ZeroYesCommand = new RelayCommand(() => ZeroYes());
			ZeroNoCommand = new RelayCommand(() => ZeroNo());
			Per1SkipCommand = new RelayCommand(() => Per1Skip());
			Per2SkipCommand = new RelayCommand(() => Per2Skip());
			Per3SkipCommand = new RelayCommand(() => Per3Skip());
			Per4SkipCommand = new RelayCommand(() => Per4Skip());
			Per5SkipCommand = new RelayCommand(() => Per5Skip());
			Per6SkipCommand = new RelayCommand(() => Per6Skip());

			Weekdays.AddRange(new List<int>
			{
				1, 2, 3, 4
			});

			FridaySet.Add(5);

			try
			{
				InfoData data = SaveSystem.LoadInfo();

				if (data != null)
				{
					Email = data.Email;
					Password = data.Password;
					ConfirmPassword = data.Password;
				}
			}
			catch {}

			try
			{
				ScheduleData data = SaveSystem.LoadSchedule();

				if (data != null)
				{
					Per0Name = data.Per0Name;
					Per0Code = data.Per0Code;
					Per0IsCode = data.Per0IsCode;

					Per1SkipChecked = data.Per1Skip;
					if (!Per1SkipChecked)
					{
						Per1Name = data.Per1Name;
						Per1Code = data.Per1Code;
						Per1IsCode = data.Per1IsCode;
						Per1MainVisibility = Visibility.Visible;
					}
					else
						Per1MainVisibility = Visibility.Collapsed;

					Per2SkipChecked = data.Per2Skip;
					if (!Per2SkipChecked)
					{
						Per2Name = data.Per2Name;
						Per2Code = data.Per2Code;
						Per2IsCode = data.Per2IsCode;
						Per2MainVisibility = Visibility.Visible;
					}
					else
						Per2MainVisibility = Visibility.Collapsed;

					Per3SkipChecked = data.Per3Skip;
					if (!Per3SkipChecked)
					{
						Per3Name = data.Per3Name;
						Per3Code = data.Per3Code;
						Per3IsCode = data.Per3IsCode;
						Per3MainVisibility = Visibility.Visible;
					}
					else
						Per3MainVisibility = Visibility.Collapsed;

					Per4SkipChecked = data.Per4Skip;
					if (!Per4SkipChecked)
					{
						Per4Name = data.Per4Name;
						Per4Code = data.Per4Code;
						Per4IsCode = data.Per4IsCode;
						Per4MainVisibility = Visibility.Visible;
					}
					else
						Per4MainVisibility = Visibility.Collapsed;

					Per5SkipChecked = data.Per5Skip;
					if (!Per5SkipChecked)
					{
						Per5Name = data.Per5Name;
						Per5Code = data.Per5Code;
						Per5IsCode = data.Per5IsCode;
						Per5MainVisibility = Visibility.Visible;
					}
					else
						Per5MainVisibility = Visibility.Collapsed;

					Per6SkipChecked = data.Per6Skip;
					if (!Per6SkipChecked)
					{
						Per6Name = data.Per6Name;
						Per6Code = data.Per6Code;
						Per6IsCode = data.Per6IsCode;
						Per6MainVisibility = Visibility.Visible;
					}
					else
						Per6MainVisibility = Visibility.Collapsed;

					if (data.ZeroIsAvaliable)
					{
						ZeroYesChecked = true;
						ZeroNoChecked = false;
						Per0Visibility = Visibility.Visible;
					}
					else
					{
						ZeroYesChecked = false;
						ZeroNoChecked = true;
						Per0Visibility = Visibility.Collapsed;
					}
				}
			}
			catch {}

			Today = DateTime.Today;

			WeekVisibility = Visibility.Visible;
			FridayVisibility = Visibility.Visible;
			SaturdayWeeklyVisibility = Visibility.Collapsed;

			try
			{
				WeeklyData data = SaveSystem.LoadWeekly();

				if (data != null)
				{
					FridayIsWhatPeriod = data.FridayIsWhichPeriod;

					if (FridayIsWhatPeriod == 1)
						FridayPer1Checked = true;
					else if (FridayIsWhatPeriod == 2)
						FridayPer2Checked = true;
					else if (FridayIsWhatPeriod == 3)
						FridayPer3Checked = true;
					else if (FridayIsWhatPeriod == 4)
						FridayPer4Checked = true;
					else if (FridayIsWhatPeriod == 5)
						FridayPer5Checked = true;
					else if (FridayIsWhatPeriod == 6)
						FridayPer6Checked = true;

					OddChecked = data.OddChecked;
					EvenChecked = data.EvenChecked;

					MondayChecked = data.MondayChecked;
					TuesdayChecked = data.TuesdayChecked;
					WednesdayChecked = data.WednesdayChecked;
					ThursdayChecked = data.ThursdayChecked;
					FridayChecked = data.FridayChecked;

					if (FridayChecked)
						FridayVisibility = Visibility.Collapsed;
				}
			}
			catch { }

			/*if (Today.DayOfWeek >= DayOfWeek.Monday)
				MondayEnabled = false;

			if (Today.DayOfWeek >= DayOfWeek.Tuesday)
				TuesdayEnabled = false;

			if (Today.DayOfWeek >= DayOfWeek.Wednesday)
				WednesdayEnabled = false;

			if (Today.DayOfWeek >= DayOfWeek.Thursday)
				ThursdayEnabled = false;

			if (Today.DayOfWeek >= DayOfWeek.Friday && Today.DayOfWeek <= DayOfWeek.Saturday)
			{
				FridayEnabled = false;
				FridayVisibility = Visibility.Collapsed;
			}*/
		}

		#endregion

		public void Per1Skip()
		{
			if (Per1SkipChecked)
				Per1MainVisibility = Visibility.Collapsed;
			else
				Per1MainVisibility = Visibility.Visible;
		}

		public void Per2Skip()
		{
			if (Per2SkipChecked)
				Per2MainVisibility = Visibility.Collapsed;
			else
				Per2MainVisibility = Visibility.Visible;
		}

		public void Per3Skip()
		{
			if (Per3SkipChecked)
				Per3MainVisibility = Visibility.Collapsed;
			else
				Per3MainVisibility = Visibility.Visible;
		}

		public void Per4Skip()
		{
			if (Per4SkipChecked)
				Per4MainVisibility = Visibility.Collapsed;
			else
				Per4MainVisibility = Visibility.Visible;
		}

		public void Per5Skip()
		{
			if (Per5SkipChecked)
				Per5MainVisibility = Visibility.Collapsed;
			else
				Per5MainVisibility = Visibility.Visible;
		}

		public void Per6Skip()
		{
			if (Per6SkipChecked)
				Per6MainVisibility = Visibility.Collapsed;
			else
				Per6MainVisibility = Visibility.Visible;
		}

		public void ZeroYes()
		{
			if (ZeroYesChecked)
			{
				if (ZeroNoChecked)
					ZeroNoChecked = false;

				Per0Visibility = Visibility.Visible;
			}
		}

		public void ZeroNo()
		{
			if (ZeroNoChecked)
			{
				if (ZeroYesChecked)
					ZeroYesChecked = false;

				Per0Visibility = Visibility.Collapsed;
			}
		}

		public void Odd()
		{
			if (OddChecked)
			{
				if (EvenChecked)
					EvenChecked = false;
			}
		}
		
		public void Even()
		{
			if (EvenChecked)
			{
				if (OddChecked)
					OddChecked = false;
			}
		}

		public async Task FridayAsync()
		{
			if (FridayChecked)
				FridayVisibility = Visibility.Collapsed;
			else
				FridayVisibility = Visibility.Visible;

			await Task.Delay(1);
		}

		public async Task BackAsync()
		{
			try
			{
				InfoData infoData = SaveSystem.LoadInfo();
				ScheduleData scheduleData = SaveSystem.LoadSchedule();
				WeeklyData weeklyData = SaveSystem.LoadWeekly();

				if (infoData != null && scheduleData != null && weeklyData != null)
				{
					if (Email != infoData.Email || Password != infoData.Password || ConfirmPassword != infoData.Password || ZeroYesChecked != scheduleData.ZeroIsAvaliable || Per0Name != scheduleData.Per0Name || Per0Code != scheduleData.Per0Code || Per1SkipChecked != scheduleData.Per1Skip || Per1Name != scheduleData.Per1Name || Per1Code != scheduleData.Per1Code || Per2SkipChecked != scheduleData.Per2Skip || Per2Name != scheduleData.Per2Name || Per2Code != scheduleData.Per2Code || Per3SkipChecked != scheduleData.Per3Skip || Per3Name != scheduleData.Per3Name || Per3Code != scheduleData.Per3Code || Per4SkipChecked != scheduleData.Per4Skip || Per4Name != scheduleData.Per4Name || Per4Code != scheduleData.Per4Code || Per5SkipChecked != scheduleData.Per5Skip || Per5Name != scheduleData.Per5Name || Per5Code != scheduleData.Per5Code || Per6SkipChecked != scheduleData.Per6Skip || Per6Name != scheduleData.Per6Name || Per6Code != scheduleData.Per6Code || FridayIsWhatPeriod != weeklyData.FridayIsWhichPeriod || OddChecked != weeklyData.OddChecked || EvenChecked != weeklyData.EvenChecked || MondayChecked != weeklyData.MondayChecked || TuesdayChecked != weeklyData.TuesdayChecked || WednesdayChecked != weeklyData.WednesdayChecked || ThursdayChecked != weeklyData.ThursdayChecked || FridayChecked != weeklyData.FridayChecked)
					{
						MessageBoxResult result = MessageBox.Show("Do you want to Save the Changes you made?", "Changes Have Been Made", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

						if (result == MessageBoxResult.Yes)
						{
							if (!(Password == ConfirmPassword))
							{
								MessageBox.Show("The Confirm Password does not match with the Password!", "Incorrect Password Fields", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
								return;
							}

							await SaveAsync(false);
						}
					}
				}
				else if (infoData == null || scheduleData == null || weeklyData == null)
				{
					if (Email != null || Password != null || ConfirmPassword != null || Per1Name != null || Per1Code != null || Per2Name != null || Per2Code != null || Per3Name != null || Per3Code != null || Per4Name != null || Per4Code != null || Per5Name != null || Per5Code != null || Per6Name != null || Per6Code != null || FridayIsWhatPeriod != 0)
					{
						if (ZeroYesChecked)
						{
							if (Per0Name != null || Per0Code != null)
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Do you want to Save the Changes you made?", "Changes Have Been Made", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

									if (result == MessageBoxResult.Yes)
									{
										if (!(Password == ConfirmPassword))
										{
											MessageBox.Show("The Confirm Password does not match with the Password!", "Incorrect Password Fields", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
											return;
										}

										await SaveAsync(false);
									}
								}
							}
						}
						else
						{
							if (OddChecked || EvenChecked)
							{
								MessageBoxResult result = MessageBox.Show("Do you want to Save the Changes you made?", "Changes Have Been Made", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Yes);

								if (result == MessageBoxResult.Yes)
								{
									if (!(Password == ConfirmPassword))
									{
										MessageBox.Show("The Confirm Password does not match with the Password!", "Incorrect Password Fields", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
										return;
									}

									await SaveAsync(false);
								}
							}
						}
					}
						
					if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
					{
						if (Per1SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per1Name) || string.IsNullOrEmpty(Per1Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}

						if (Per2SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per2Name) || string.IsNullOrEmpty(Per2Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}

						if (Per3SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per3Name) || string.IsNullOrEmpty(Per3Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}

						if (Per4SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per4Name) || string.IsNullOrEmpty(Per4Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}

						if (Per5SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per5Name) || string.IsNullOrEmpty(Per5Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}

						if (Per6SkipChecked)
						{
							if (ZeroYesChecked)
							{
								if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
							else
							{
								if (OddChecked || EvenChecked)
								{
									MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
									return;
								}
							}
						}
						else
						{
							if (string.IsNullOrEmpty(Per6Name) || string.IsNullOrEmpty(Per6Code))
							{
								if (ZeroYesChecked)
								{
									if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
									{
										if (OddChecked || EvenChecked)
										{
											MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
											return;
										}
									}
								}
								else
								{
									if (OddChecked || EvenChecked)
									{
										MessageBoxResult result = MessageBox.Show("Please Fill Out All of the Fields Before Leaving", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
										return;
									}
								}
							}
						}
					}
				}
			}
			catch {}

			IoC.Application.SetupMenuVisible = false;

			await Task.Delay(1);
		}

		public async Task SaveAsync(object parameter)
		{
			await RunCommandAsync(() => SaveIsRunning, async () =>
			{
				if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
				{
					MessageBox.Show("Please Make Sure You Inputed all the Personal Information Fields.", "Missing Info Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
					return;
				}

				if (ZeroYesChecked)
				{
					if (string.IsNullOrEmpty(Per0Name) || string.IsNullOrEmpty(Per0Code))
					{
						MessageBox.Show("Please Make Sure You Inputed the Zero Period Information Fields.", "Missing Zero Period Info Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
						return;
					}
				}

				if (string.IsNullOrEmpty(Per1Name) || string.IsNullOrEmpty(Per1Code) || string.IsNullOrEmpty(Per2Name) || string.IsNullOrEmpty(Per2Code) || string.IsNullOrEmpty(Per3Name) || string.IsNullOrEmpty(Per3Code) || string.IsNullOrEmpty(Per4Name) || string.IsNullOrEmpty(Per4Code) || string.IsNullOrEmpty(Per5Name) || string.IsNullOrEmpty(Per5Code) || string.IsNullOrEmpty(Per6Name) || string.IsNullOrEmpty(Per6Code))
				{
					MessageBox.Show("Please Make Sure You Inputed all the Class Period Information Fields.", "Missing Period Info Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
					return;
				}

				if (Today.DayOfWeek < DayOfWeek.Friday && Today.DayOfWeek > DayOfWeek.Saturday)
				{
					if (!FridayPer1Checked && !FridayPer2Checked && !FridayPer3Checked && !FridayPer4Checked && !FridayPer5Checked && !FridayPer6Checked)
					{
						MessageBox.Show("Please Make Sure You Have Completed the Friday Setup Area.", "Missing Friday Setup", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
						return;
					}
				}

				if (!OddChecked && !EvenChecked)
				{
					MessageBox.Show("Please Make Sure You Have Completed the Weekly Schedule Setup Area.", "Missing Week's Setup", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
					return;
				}

				if (!(Password == ConfirmPassword))
				{
					MessageBox.Show("The Confirm Password does not match with the Password!", "Incorrect Password Fields", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
					return;
				}

				if (ZeroYesChecked)
				{
					if (Per0Code.Contains("http"))
						Per0IsCode = false;
					else
						Per0IsCode = true;
				}

				if (Per1Code.Contains("http"))
					Per1IsCode = false;
				else
					Per1IsCode = true;

				if (Per2Code.Contains("http"))
					Per2IsCode = false;
				else
					Per2IsCode = true;

				if (Per3Code.Contains("http"))
					Per3IsCode = false;
				else
					Per3IsCode = true;

				if (Per4Code.Contains("http"))
					Per4IsCode = false;
				else
					Per4IsCode = true;

				if (Per5Code.Contains("http"))
					Per5IsCode = false;
				else
					Per5IsCode = true;

				if (Per6Code.Contains("http"))
					Per6IsCode = false;
				else
					Per6IsCode = true;

				if (Today.DayOfWeek != DayOfWeek.Friday)
				{
					if (FridayIsWhatPeriod == 1)
					{
						if (!Per1SkipChecked)
						{
							FridayName = Per1Name;
							FridayCode = Per1Code;
							FridayIsCode = Per1IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
					else if (FridayIsWhatPeriod == 2)
					{
						if (!Per2SkipChecked)
						{
							FridayName = Per2Name;
							FridayCode = Per2Code;
							FridayIsCode = Per2IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
					else if (FridayIsWhatPeriod == 3)
					{
						if (!Per3SkipChecked)
						{
							FridayName = Per3Name;
							FridayCode = Per3Code;
							FridayIsCode = Per3IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
					else if (FridayIsWhatPeriod == 4)
					{
						if (!Per4SkipChecked)
						{
							FridayName = Per4Name;
							FridayCode = Per4Code;
							FridayIsCode = Per4IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
					else if (FridayIsWhatPeriod == 5)
					{
						if (!Per5SkipChecked)
						{
							FridayName = Per5Name;
							FridayCode = Per5Code;
							FridayIsCode = Per5IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
					else if (FridayIsWhatPeriod == 6)
					{
						if (!Per6SkipChecked)
						{
							FridayName = Per6Name;
							FridayCode = Per6Code;
							FridayIsCode = Per6IsCode;
							FridaySkip = false;
						}
						else
							FridaySkip = true;
					}
				}

				if (MondayChecked)
					Weekdays.Remove(1);

				if (TuesdayChecked)
					Weekdays.Remove(2);

				if (WednesdayChecked)
					Weekdays.Remove(3);

				if (ThursdayChecked)
					Weekdays.Remove(4);

				if (FridayChecked)
					FridaySet.Remove(5);

				int oddOrEven = 0;

				if (OddChecked)
				{
					foreach (int days in Weekdays)
					{
						if (oddOrEven == 0)
						{
							OddSet.Add(days);
							oddOrEven = 1;
						}
						else if (oddOrEven == 1)
						{
							EvenSet.Add(days);
							oddOrEven = 0;
						}
					}
				}
				else if (EvenChecked)
				{
					foreach (int days in Weekdays)
					{
						if (oddOrEven == 0)
						{
							EvenSet.Add(days);
							oddOrEven = 1;
						}
						else if (oddOrEven == 1)
						{
							OddSet.Add(days);
							oddOrEven = 0;
						}
					}
				}

				if (Today.DayOfWeek == DayOfWeek.Sunday)
					DateForSetupToDelete = Today.AddDays(7);
				else if (Today.DayOfWeek == DayOfWeek.Monday)
					DateForSetupToDelete = Today.AddDays(6);
				else if (Today.DayOfWeek == DayOfWeek.Tuesday)
					DateForSetupToDelete = Today.AddDays(5);
				else if (Today.DayOfWeek == DayOfWeek.Wednesday)
					DateForSetupToDelete = Today.AddDays(4);
				else if (Today.DayOfWeek == DayOfWeek.Thursday)
					DateForSetupToDelete = Today.AddDays(3);
				else if (Today.DayOfWeek == DayOfWeek.Friday)
					DateForSetupToDelete = Today.AddDays(2);
				else if (Today.DayOfWeek == DayOfWeek.Saturday)
					DateForSetupToDelete = Today.AddDays(1);

				SaveSystem.SaveInfo(this);
				SaveSystem.SaveSchedule(this);

				SaveSystem.SaveWeekly(this);

				await Task.Delay(1000);
			});
		}

		public async Task FridayPer1Async()
		{
			FridayIsWhatPeriod = 1;

			if (FridayPer1Checked)
			{
				if (FridayPer2Checked)
					FridayPer2Checked = false;
				else if (FridayPer3Checked)
					FridayPer3Checked = false;
				else if (FridayPer4Checked)
					FridayPer4Checked = false;
				else if (FridayPer5Checked)
					FridayPer5Checked = false;
				else if (FridayPer6Checked)
					FridayPer6Checked = false;
			}

			await Task.Delay(1);
		}

		public async Task FridayPer2Async()
		{
			FridayIsWhatPeriod = 2;

			if (FridayPer2Checked)
			{
				if (FridayPer1Checked)
					FridayPer1Checked = false;
				else if (FridayPer3Checked)
					FridayPer3Checked = false;
				else if (FridayPer4Checked)
					FridayPer4Checked = false;
				else if (FridayPer5Checked)
					FridayPer5Checked = false;
				else if (FridayPer6Checked)
					FridayPer6Checked = false;
			}

			await Task.Delay(1);
		}

		public async Task FridayPer3Async()
		{
			FridayIsWhatPeriod = 3;

			if (FridayPer3Checked)
			{
				if (FridayPer1Checked)
					FridayPer1Checked = false;
				else if (FridayPer2Checked)
					FridayPer2Checked = false;
				else if (FridayPer4Checked)
					FridayPer4Checked = false;
				else if (FridayPer5Checked)
					FridayPer5Checked = false;
				else if (FridayPer6Checked)
					FridayPer6Checked = false;
			}

			await Task.Delay(1);
		}

		public async Task FridayPer4Async()
		{
			FridayIsWhatPeriod = 4;

			if (FridayPer4Checked)
			{
				if (FridayPer1Checked)
					FridayPer1Checked = false;
				else if (FridayPer2Checked)
					FridayPer2Checked = false;
				else if (FridayPer3Checked)
					FridayPer3Checked = false;
				else if (FridayPer5Checked)
					FridayPer5Checked = false;
				else if (FridayPer6Checked)
					FridayPer6Checked = false;
			}

			await Task.Delay(1);
		}

		public async Task FridayPer5Async()
		{
			FridayIsWhatPeriod = 5;

			if (FridayPer5Checked)
			{
				if (FridayPer1Checked)
					FridayPer1Checked = false;
				else if (FridayPer2Checked)
					FridayPer2Checked = false;
				else if (FridayPer3Checked)
					FridayPer3Checked = false;
				else if (FridayPer4Checked)
					FridayPer4Checked = false;
				else if (FridayPer6Checked)
					FridayPer6Checked = false;
			}

			await Task.Delay(1);
		}

		public async Task FridayPer6Async()
		{
			FridayIsWhatPeriod = 6;

			if (FridayPer6Checked)
			{
				if (FridayPer1Checked)
					FridayPer1Checked = false;
				else if (FridayPer2Checked)
					FridayPer2Checked = false;
				else if (FridayPer3Checked)
					FridayPer3Checked = false;
				else if (FridayPer4Checked)
					FridayPer4Checked = false;
				else if (FridayPer5Checked)
					FridayPer5Checked = false;
			}

			await Task.Delay(1);
		}
	}
}
