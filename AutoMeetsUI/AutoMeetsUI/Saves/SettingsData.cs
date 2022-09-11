using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	[System.Serializable]
	public class SettingsData
	{
		public int OffsetMin;

		public bool StartUpChecked;

		public bool LightModeChecked;
		public bool DarkModeChecked;

		public SettingsData(SettingsViewModel settingsFile)
		{
			OffsetMin = settingsFile.OffsetMin;
			StartUpChecked = settingsFile.StartUpChecked;
			LightModeChecked = settingsFile.LightModeChecked;
			DarkModeChecked = settingsFile.DarkModeChecked;
		}
	}
}
