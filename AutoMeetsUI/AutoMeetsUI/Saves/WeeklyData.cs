using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	[System.Serializable]
	public class WeeklyData
	{
		public List<int> Weekdays;
		public List<int> FridaySet;

		public List<int> OddSet;
		public List<int> EvenSet;

		public string FridayName;
		public string FridayCode;
		public bool FridayIsCode;
		public int FridayIsWhichPeriod;
		public bool FridaySkip;

		public bool OddChecked;
		public bool EvenChecked;

		public bool MondayChecked;
		public bool TuesdayChecked;
		public bool WednesdayChecked;
		public bool ThursdayChecked;
		public bool FridayChecked;

		public DateTime DateToDelete;

		public WeeklyData(SetupViewModel setupFile)
		{
			Weekdays = setupFile.Weekdays;
			FridaySet = setupFile.FridaySet;

			OddSet = setupFile.OddSet;
			EvenSet = setupFile.EvenSet;

			FridayName = setupFile.FridayName;
			FridayCode = setupFile.FridayCode;
			FridayIsCode = setupFile.FridayIsCode;
			FridayIsWhichPeriod = setupFile.FridayIsWhatPeriod;
			FridaySkip = setupFile.FridaySkip;

			OddChecked = setupFile.OddChecked;
			EvenChecked = setupFile.EvenChecked;

			MondayChecked = setupFile.MondayChecked;
			TuesdayChecked = setupFile.TuesdayChecked;
			WednesdayChecked = setupFile.WednesdayChecked;
			ThursdayChecked = setupFile.ThursdayChecked;
			FridayChecked = setupFile.FridayChecked;

			DateToDelete = setupFile.DateForSetupToDelete;
		}

		// TODO: Recopy this \/
		public WeeklyData(SetupPageViewModel setupFile)
		{
			//Weekdays = setupFile.Week;

			FridayName = setupFile.FridayName;
			FridayCode = setupFile.FridayCode;
			FridayIsCode = setupFile.FridayIsCode;
			FridayIsWhichPeriod = setupFile.FridayIsWhatPeriod;

			OddChecked = setupFile.OddChecked;
			EvenChecked = setupFile.EvenChecked;

			MondayChecked = setupFile.MondayChecked;
			TuesdayChecked = setupFile.TuesdayChecked;
			WednesdayChecked = setupFile.WednesdayChecked;
			ThursdayChecked = setupFile.ThursdayChecked;
			FridayChecked = setupFile.FridayChecked;
		}
	}
}
