using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ByteSizeLib;

namespace AutoMeetUpdater
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
                        MBText.Visibility = Visibility.Hidden;
                        FadeOut(1);
                        Launch();
                        break;
					case LauncherStatus.failed:
                        UpdateText.Text = "Update Failed, Retrying";
                        MBText.Visibility = Visibility.Visible;
                        break;
					case LauncherStatus.downloadingProgram:
                        UpdateText.Text = "Downloading the Latest Release of AutoMeets";
                        MBText.Visibility = Visibility.Visible;
                        break;
					case LauncherStatus.downloadingUpdate:
                        UpdateText.Text = "Downloading New Update";
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
            rootPath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\Program"));
            versionFile = Path.Combine(rootPath, "Version.txt");
			gameZip = Path.Combine(rootPath, "Build.zip");
			gameExe = Path.Combine(rootPath, "Build", "AutoMeetsST.exe");

            FadeInFunction();
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
                    Version onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1DoumvU0imJIDWvPC_o3uCHSEaIkpO7d6"));

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
                    _onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1DoumvU0imJIDWvPC_o3uCHSEaIkpO7d6"));
                }

                FileDownloader fileDownloader = new FileDownloader();

                fileDownloader.DownloadProgressChanged += (sender, e) => Console.WriteLine("Progress changed " + e.BytesReceived + " " + e.TotalBytesToReceive);
                fileDownloader.DownloadProgressChanged += new FileDownloader.DownloadProgressChangedEventHandler(ProgressBarUpdate);
                fileDownloader.DownloadProgressChanged += (sender, e) => MBText.Text = ByteSize.FromBytes(e.BytesReceived).ToString() + "/" + ByteSize.FromBytes(e.TotalBytesToReceive);

                fileDownloader.DownloadFileCompleted += (sender, e) => DownloadGameCompleted(sender, e);

                fileDownloader.DownloadFileAsync("https://drive.google.com/uc?export=download&id=1NEUkp00c6oOrnGFplcJEcHeq3Mfea1cP", gameZip, _onlineVersion);
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error installing program files: {ex}");
            }
        }

        private void DownloadGameCompleted(object sender, AsyncCompletedEventArgs e)
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

        async void FadeInFunction()
		{
            await Task.Delay(500);
            FadeIn(1);
        }

        async void Launch()
		{
            if (File.Exists(gameExe) && Status == LauncherStatus.ready)
            {
                await Task.Delay(2000);
                ProcessStartInfo startInfo = new ProcessStartInfo(gameExe);
                startInfo.WorkingDirectory = Path.Combine(rootPath, "Build");
                Process.Start(startInfo);

                Close();
            }
            else if (Status == LauncherStatus.failed)
            {
                await Task.Delay(2000);
                CheckForUpdates();
            }
        }

        private void ProgressBarUpdate(object sender, FileDownloader.DownloadProgress e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        void FadeIn(int time)
		{
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(time)),
                AutoReverse = false
            };
            AutoMeetLogo.BeginAnimation(OpacityProperty, da);
        }

        void FadeOut(int time)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(time)),
                AutoReverse = false
            };
            AutoMeetLogo.BeginAnimation(OpacityProperty, da);
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
