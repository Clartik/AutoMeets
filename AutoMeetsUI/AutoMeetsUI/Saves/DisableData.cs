using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	[System.Serializable]
	public class DisableData
	{
		public int DisableDate;

		public DisableData(SettingsViewModel settingsFile)
		{
			DisableDate = settingsFile.DisableDate;
		}
	}
}
