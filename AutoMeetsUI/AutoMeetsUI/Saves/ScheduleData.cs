using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	[System.Serializable]
	public class ScheduleData
	{
		public string Per0Name;
		public string Per0Code;
		public bool Per0IsCode;
		public bool ZeroIsAvaliable;

		public string Per1Name;
		public string Per1Code;
		public bool Per1IsCode;
		public bool Per1Skip;

		public string Per2Name;
		public string Per2Code;
		public bool Per2IsCode;
		public bool Per2Skip;

		public string Per3Name;
		public string Per3Code;
		public bool Per3IsCode;
		public bool Per3Skip;

		public string Per4Name;
		public string Per4Code;
		public bool Per4IsCode;
		public bool Per4Skip;

		public string Per5Name;
		public string Per5Code;
		public bool Per5IsCode;
		public bool Per5Skip;

		public string Per6Name;
		public string Per6Code;
		public bool Per6IsCode;
		public bool Per6Skip;

		public ScheduleData(SetupViewModel setupFile)
		{
			ZeroIsAvaliable = setupFile.ZeroYesChecked;

			Per0Name = setupFile.Per0Name;
			Per0Code = setupFile.Per0Code;
			Per0IsCode = setupFile.Per0IsCode;

			Per1Skip = setupFile.Per1SkipChecked;
			if (!Per1Skip)
			{
				Per1Name = setupFile.Per1Name;
				Per1Code = setupFile.Per1Code;
				Per1IsCode = setupFile.Per1IsCode;
			}

			Per2Skip = setupFile.Per2SkipChecked;
			if (!Per2Skip)
			{
				Per2Name = setupFile.Per2Name;
				Per2Code = setupFile.Per2Code;
				Per2IsCode = setupFile.Per2IsCode;
			}

			Per3Skip = setupFile.Per3SkipChecked;
			if (!Per3Skip)
			{
				Per3Name = setupFile.Per3Name;
				Per3Code = setupFile.Per3Code;
				Per3IsCode = setupFile.Per3IsCode;
			}

			Per4Skip = setupFile.Per4SkipChecked;
			if (!Per4Skip)
			{
				Per4Name = setupFile.Per4Name;
				Per4Code = setupFile.Per4Code;
				Per4IsCode = setupFile.Per4IsCode;
			}

			Per5Skip = setupFile.Per5SkipChecked;
			if (!Per5Skip)
			{
				Per5Name = setupFile.Per5Name;
				Per5Code = setupFile.Per5Code;
				Per5IsCode = setupFile.Per5IsCode;
			}

			Per6Skip = setupFile.Per6SkipChecked;
			if (!Per6Skip)
			{
				Per6Name = setupFile.Per6Name;
				Per6Code = setupFile.Per6Code;
				Per6IsCode = setupFile.Per6IsCode;
			}
		}

		// TODO: FIX THIS
		public ScheduleData(SetupPageViewModel setupFile)
		{
			ZeroIsAvaliable = setupFile.ZeroYesChecked;

			Per0Name = setupFile.Per0Name;
			Per0Code = setupFile.Per0Code;
			Per0IsCode = setupFile.Per0IsCode;

			Per1Name = setupFile.Per1Name;
			Per1Code = setupFile.Per1Code;
			Per1IsCode = setupFile.Per1IsCode;

			Per2Name = setupFile.Per2Name;
			Per2Code = setupFile.Per2Code;
			Per2IsCode = setupFile.Per2IsCode;

			Per3Name = setupFile.Per3Name;
			Per3Code = setupFile.Per3Code;
			Per3IsCode = setupFile.Per3IsCode;

			Per4Name = setupFile.Per4Name;
			Per4Code = setupFile.Per4Code;
			Per4IsCode = setupFile.Per4IsCode;

			Per5Name = setupFile.Per5Name;
			Per5Code = setupFile.Per5Code;
			Per5IsCode = setupFile.Per5IsCode;

			Per6Name = setupFile.Per6Name;
			Per6Code = setupFile.Per6Code;
			Per6IsCode = setupFile.Per6IsCode;
		}
	}
}
