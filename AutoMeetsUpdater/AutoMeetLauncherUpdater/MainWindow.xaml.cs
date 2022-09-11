using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using ByteSizeLib;

namespace AutoMeetLauncherUpdater
{
	enum LauncherStatus
	{
		ready,
		failed,
		downloadingProgram,
		downloadingUpdate
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string currentPath;
		private string rootPath;
		private string versionFile;
		private string gameZip;
		private string gameExe;

		private LauncherStatus _status;
		internal LauncherStatus Status
		{
			get => _status;
			set
			{
				_status = value;
				switch (_status)
				{
					case LauncherStatus.ready:
						UpdateText.Text = "You have the Latest Release";
						ProgressBar.Value = 100;
						ProgressBar.Visibility = Visibility.Hidden;
						MBText.Visibility = Visibility.Hidden;
						Launch();
						break;
					case LauncherStatus.failed:
						UpdateText.Text = "Update Failed, Retrying";
						ProgressBar.Visibility = Visibility.Visible;
						MBText.Visibility = Visibility.Visible;
						Launch();
						break;
					case LauncherStatus.downloadingProgram:
						UpdateText.Text = "Downloading the Latest Release of AutoMeets Launcher";
						ProgressBar.Visibility = Visibility.Visible;
						MBText.Visibility = Visibility.Visible;
						break;
					case LauncherStatus.downloadingUpdate:
						UpdateText.Text = "Downloading New Update";
						ProgressBar.Visibility = Visibility.Visible;
						MBText.Visibility = Visibility.Visible;
						break;
					default:
						break;
				}
			}

		}

		public MainWindow()
		{
			InitializeComponent();

			currentPath = Directory.GetCurrentDirectory();
			rootPath = Path.GetFullPath(Path.Combine(currentPath, @"Apps\Launcher\"));
			versionFile = Path.Combine(rootPath, "Version.txt");
			gameZip = Path.Combine(rootPath, "LauncherBuild.zip");
			gameExe = Path.Combine(rootPath, "LauncherBuild", "AutoMeetsUpdater.exe");
		}

		private void CheckForUpdates()
		{
			if (File.Exists(versionFile))
			{
				Version localVersion = new Version(File.ReadAllText(versionFile));
				VersionText.Text = localVersion.ToString();

				try
				{
					WebClient webClient = new WebClient();
					Version onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1cLdje7s3U8bW3vKViuI-5UM9YUxX8IV7"));

					if (onlineVersion.IsDifferentThan(localVersion))
					{
						InstallGameFiles(true, onlineVersion);
					}
					else
					{
						Status = LauncherStatus.ready;
					}
				}
				catch (Exception ex)
				{
					Status = LauncherStatus.failed;
					MessageBox.Show($"Error checking for updates: {ex}");
				}
			}
			else
			{
				InstallGameFiles(false, Version.zero);
			}
		}

		private void InstallGameFiles(bool _isUpdate, Version _onlineVersion)
		{
			try
			{
				WebClient webClient = new WebClient();
				if (_isUpdate)
				{
					Status = LauncherStatus.downloadingUpdate;
				}
				else
				{
					Status = LauncherStatus.downloadingProgram;
					_onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1cLdje7s3U8bW3vKViuI-5UM9YUxX8IV7"));
				}

				FileDownloader fileDownloader = new FileDownloader();

				fileDownloader.DownloadProgressChanged += (sender, e) => Console.WriteLine("Progress changed " + e.BytesReceived + " " + e.TotalBytesToReceive);
				fileDownloader.DownloadProgressChanged += new FileDownloader.DownloadProgressChangedEventHandler(ProgressBarUpdate);
				fileDownloader.DownloadProgressChanged += (sender, e) => MBText.Text = ByteSize.FromBytes(e.BytesReceived).ToString() + "/" + ByteSize.FromBytes(e.TotalBytesToReceive);

				fileDownloader.DownloadFileCompleted += (sender, e) => DownloadGameCompletedCallback(sender, e);

				fileDownloader.DownloadFileAsync("https://drive.google.com/uc?export=download&id=1ayfp7B46OSxb88zw7aVHbDopJ3yoTl3v", gameZip, _onlineVersion);
			}
			catch (Exception ex)
			{
				Status = LauncherStatus.failed;
				MessageBox.Show($"Error installing program files: {ex}");
			}
		}

		private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				string onlineVersion = ((Version)e.UserState).ToString();
				ZipFile.ExtractToDirectory(gameZip, rootPath, true);
				File.Delete(gameZip);

				File.WriteAllText(versionFile, onlineVersion);

				VersionText.Text = onlineVersion;
				Status = LauncherStatus.ready;
			}
			catch (Exception ex)
			{
				Status = LauncherStatus.failed;
				MessageBox.Show($"Error finishing download: {ex}");
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			CheckForUpdates();
		}

		async void Launch()
		{
			if (File.Exists(gameExe) && Status == LauncherStatus.ready)
			{
				await Task.Delay(1000);
				ProcessStartInfo startInfo = new ProcessStartInfo(gameExe);
				startInfo.WorkingDirectory = Path.Combine(rootPath, "LauncherBuild");
				Process.Start(startInfo);

				Close();
			}
			else if (Status == LauncherStatus.failed)
			{
				await Task.Delay(3000);
				CheckForUpdates();
			}
		}

		private void ProgressBarUpdate(object sender, FileDownloader.DownloadProgress e)
		{
			this.ProgressBar.Value = e.ProgressPercentage;
		}
	}

	struct Version
	{
		internal static Version zero = new Version(0, 0, 0);

		private short major;
		private short minor;
		private short subMinor;

		internal Version(short _major, short _minor, short _subMinor)
		{
			major = _major;
			minor = _minor;
			subMinor = _subMinor;
		}
		internal Version(string _version)
		{
			string[] versionStrings = _version.Split('.');
			if (versionStrings.Length != 3)
			{
				major = 0;
				minor = 0;
				subMinor = 0;
				return;
			}

			major = short.Parse(versionStrings[0]);
			minor = short.Parse(versionStrings[1]);
			subMinor = short.Parse(versionStrings[2]);
		}

		internal bool IsDifferentThan(Version _otherVersion)
		{
			if (major != _otherVersion.major)
			{
				return true;
			}
			else
			{
				if (minor != _otherVersion.minor)
				{
					return true;
				}
				else
				{
					if (subMinor != _otherVersion.subMinor)
					{
						return true;
					}
				}
			}
			return false;
		}

		public override string ToString()
		{
			return $"{major}.{minor}.{subMinor}";
		}
	}
}
