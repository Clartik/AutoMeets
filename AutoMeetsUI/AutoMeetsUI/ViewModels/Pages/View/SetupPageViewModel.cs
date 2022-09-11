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
	public class SetupPageViewModel : BaseViewModel
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

		public bool ZeroYesChecked { get; set; }
		public bool ZeroNoChecked { get; set; }

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

		/// <summary>
		/// A bool to check if the Tuesday Toggle Button is selected or not
		/// </summary>
		public bool TuesdayChecked { get; set; }

		/// <summary>
		/// A bool to check if the Wednesday Toggle Button is selected or not
		/// </summary>
		public bool WednesdayChecked { get; set; }

		/// <summary>
		/// A bool to check if the Thursday Toggle Button is selected or not
		/// </summary>
		public bool ThursdayChecked { get; set; }

		/// <summary>
		/// A bool to check if the Friday Toggle Button is selected or not
		/// </summary>
		public bool FridayChecked { get; set; }

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

		public int[] Week { get; set; } = { 1, 2, 3, 4, 5 };

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

		public Visibility InfoVisibility { get; set; }

		public Visibility LeftPeriodVisibility { get; set; }

		public Visibility RightPeriodVisibility { get; set; }

		#endregion

		#region Public Commands

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

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SetupPageViewModel()
		{
			SaveCommand = new RelayCommand(() => SaveAsync());
			OddCommand = new RelayCommand(() => Odd());
			EvenCommand = new RelayCommand(() => Even());

			FridayPer1Command = new RelayCommand(async() => await FridayPer1Async());
			FridayPer2Command = new RelayCommand(async() => await FridayPer2Async());
			FridayPer3Command = new RelayCommand(async() => await FridayPer3Async());
			FridayPer4Command = new RelayCommand(async() => await FridayPer4Async());
			FridayPer5Command = new RelayCommand(async() => await FridayPer5Async());
			FridayPer6Command = new RelayCommand(async() => await FridayPer6Async());
		}

		#endregion

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

		public void SaveAsync()
		{
			if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
			{
				MessageBox.Show("Please Make Sure You Inputed all the Personal Information Fields.", "Missing Info Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
				return;
			}

			if (string.IsNullOrEmpty(Per1Name) || string.IsNullOrEmpty(Per1Code) || string.IsNullOrEmpty(Per2Name) || string.IsNullOrEmpty(Per2Code) || string.IsNullOrEmpty(Per3Name) || string.IsNullOrEmpty(Per3Code) || string.IsNullOrEmpty(Per4Name) || string.IsNullOrEmpty(Per4Code) || string.IsNullOrEmpty(Per5Name) || string.IsNullOrEmpty(Per5Code) || string.IsNullOrEmpty(Per6Name) || string.IsNullOrEmpty(Per6Code))
			{
				MessageBox.Show("Please Make Sure You Inputed all the Class Period Information Fields.", "Missing Period Info Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
				return;
			}

			if (!FridayPer1Checked && !FridayPer2Checked && !FridayPer3Checked && !FridayPer4Checked && !FridayPer5Checked && !FridayPer6Checked)
			{
				MessageBox.Show("Please Make Sure You Have Completed the Friday Setup Area.", "Missing Friday Setup", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
				return;
			}

			if (!OddChecked && !EvenChecked)
			{
				MessageBox.Show("Please Make Sure You Have Completed the Weekly Schedule Setup Area.", "Missing Week's Setup", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
				return;
			}

			if (!MondayChecked && !TuesdayChecked && !WednesdayChecked && !ThursdayChecked && !FridayChecked)
			{
				MessageBox.Show("Please Make Sure You Have Completed the Weekly Schedule Setup Area.", "Missing Week's Setup", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
				return;
			}

			if (!(Password == ConfirmPassword))
			{
				MessageBox.Show("The Confirm Password does not match with the Password!", "Incorrect Password Fields", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
				return;
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

			if (FridayIsWhatPeriod == 1)
				FridayIsCode = Per1IsCode;
			else if (FridayIsWhatPeriod == 2)
				FridayIsCode = Per2IsCode;
			else if (FridayIsWhatPeriod == 3)
				FridayIsCode = Per3IsCode;
			else if (FridayIsWhatPeriod == 4)
				FridayIsCode = Per4IsCode;
			else if (FridayIsWhatPeriod == 5)
				FridayIsCode = Per5IsCode;
			else if (FridayIsWhatPeriod == 6)
				FridayIsCode = Per6IsCode;

			if (MondayChecked)
			{
				int index = Week.FindIndex(1);
				Week = Week.RemoveAt(index);
			}

			if (TuesdayChecked)
			{
				int index = Week.FindIndex(2);
				Week = Week.RemoveAt(index);
			}

			if (WednesdayChecked)
			{
				int index = Week.FindIndex(3);
				Week = Week.RemoveAt(index);
			}

			if (ThursdayChecked)
			{
				int index = Week.FindIndex(4);
				Week = Week.RemoveAt(index);
			}

			if (FridayChecked)
			{
				int index = Week.FindIndex(5);
				Week = Week.RemoveAt(index);
			}

			SaveSystem.SaveInfo(this);
			SaveSystem.SaveSchedule(this);
			SaveSystem.SaveWeekly(this);

			IoC.Application.GoToPage(ApplicationPage.Default);
		}

		public async Task FridayPer1Async()
		{
			FridayName = Per1Name;
			FridayCode = Per1Code;
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
			FridayName = Per2Name;
			FridayCode = Per2Code;
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
			FridayName = Per3Name;
			FridayCode = Per3Code;
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
			FridayName = Per4Name;
			FridayCode = Per4Code;
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
			FridayName = Per5Name;
			FridayCode = Per5Code;
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
			FridayName = Per6Name;
			FridayCode = Per6Code;
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
