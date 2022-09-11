using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	[System.Serializable]
	public class InfoData
	{
		public string Email;
		public string Password;

		public InfoData(SetupViewModel setupFile)
		{
			Email = setupFile.Email;
			Password = setupFile.Password;
		}

		public InfoData(SetupPageViewModel setupPageFile)
		{
			Email = setupPageFile.Email;
			Password = setupPageFile.Password;
		}
	}
}
