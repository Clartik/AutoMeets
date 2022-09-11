using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;

namespace AutoMeetsUI
{
	public static class SaveSystem
	{
		#region Schedule

		public static void SaveSchedule(SetupViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "ClassSchedule.am", FileMode.Create);

			ScheduleData data = new ScheduleData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static void SaveSchedule(SetupPageViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "ClassSchedule.am", FileMode.Create);

			ScheduleData data = new ScheduleData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static ScheduleData LoadSchedule()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\ClassSchedule.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				ScheduleData data = formatter.Deserialize(stream) as ScheduleData;
				stream.Close();

				return data;
			}
			else
			{
				//MessageBox.Show("An Error occured while loading your school schedule.", "Unable to Load School Schedule", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				return null;
			}
		}

		public static void DeleteSchedule()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\ClassSchedule.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
				File.Delete(path);
		}

		#endregion

		#region Weekly Schedule

		public static void SaveWeekly(SetupViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "WeeklySchedule.am", FileMode.Create);

			WeeklyData data = new WeeklyData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static void SaveWeekly(SetupPageViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "WeeklySchedule.am", FileMode.Create);

			WeeklyData data = new WeeklyData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static WeeklyData LoadWeekly()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\WeeklySchedule.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				WeeklyData data = formatter.Deserialize(stream) as WeeklyData;
				stream.Close();

				return data;
			}
			else
			{
				//MessageBox.Show("An Error occured while loading this week's schedule.", "Unable to Load Week Schedule", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				return null;
			}
		}

		public static void DeleteWeekly()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\WeeklySchedule.am";
			path = Environment.ExpandEnvironmentVariables(path);
			
			if (File.Exists(path))
				File.Delete(path);
		}

		#endregion

		#region Info

		public static void SaveInfo(SetupViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "INFO.am", FileMode.Create);

			InfoData data = new InfoData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static void SaveInfo(SetupPageViewModel setupFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "INFO.am", FileMode.Create);

			InfoData data = new InfoData(setupFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static InfoData LoadInfo()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\INFO.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				InfoData data = formatter.Deserialize(stream) as InfoData;
				stream.Close();

				return data;
			}
			else
			{
				//MessageBox.Show("An Error occured while loading your personal information.", "Unable to Load Personal Information", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				return null;
			}
		}

		public static void DeleteInfo()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\INFO.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
				File.Delete(path);
		}

		#endregion

		#region Settings

		public static void SaveSettings(SettingsViewModel settingsFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "Settings.am", FileMode.Create);

			SettingsData data = new SettingsData(settingsFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static SettingsData LoadSettings()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\Settings.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				SettingsData data = formatter.Deserialize(stream) as SettingsData;
				stream.Close();

				return data;
			}
			else
			{
				//MessageBox.Show("An Error occured while loading your personal information.", "Unable to Load Personal Information", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
				return null;
			}
		}

		public static void DeleteSettings()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\Settings.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
				File.Delete(path);
		}

		#endregion

		#region Disable

		public static void SaveDisable(SettingsViewModel settingsFile)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			string path = @"%APPDATA%\AutoMeets\Saves\";
			path = Environment.ExpandEnvironmentVariables(path);
			Directory.CreateDirectory(path);

			FileStream stream = new FileStream(path + "DisableTemp.am", FileMode.Create);

			DisableData data = new DisableData(settingsFile);

			formatter.Serialize(stream, data);
			stream.Close();
		}

		public static DisableData LoadDisable()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\DisableTemp.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				DisableData data = formatter.Deserialize(stream) as DisableData;
				stream.Close();

				return data;
			}
			else
			{
				return null;
			}
		}

		public static void DeleteDisable()
		{
			string path = @"%APPDATA%\AutoMeets\Saves\DisableTemp.am";
			path = Environment.ExpandEnvironmentVariables(path);

			if (File.Exists(path))
				File.Delete(path);
		}

		#endregion
	}
}
