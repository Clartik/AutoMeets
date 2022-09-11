using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AutoMeetsUI
{
	/// <summary>
	/// Interaction logic for DefaultPage.xaml
	/// </summary>
	public partial class DefaultPage : BasePage<DefaultViewModel>
	{
		public DefaultPage()
		{
			InitializeComponent();
		}

		private void YellowRect_Loaded(object sender, RoutedEventArgs e)
		{
			YellowRect.Width = NextClassTextDark.ActualWidth + 25;
		}

		/*private void NextClassTextDark_TargetUpdated(object sender, DataTransferEventArgs e)
		{
			YellowRect.Width = NextClassTextDark.ActualWidth + 25;
		}*/

		/*void AnimateScroll()
		{
			double height = InfoTextCanvas.ActualHeight - InfoText.ActualHeight;
			InfoText.Margin = new Thickness(0, height / 2, 0, 0);
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = InfoText.ActualWidth;
			doubleAnimation.To = -InfoTextCanvas.ActualWidth;
			doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
			doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(60));
			InfoText.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
		}

		void AnimateScrollDark()
		{
			double height = InfoTextCanvasDark.ActualHeight - InfoTextDark.ActualHeight;
			InfoTextDark.Margin = new Thickness(0, height / 2, 0, 0);
			DoubleAnimation doubleAnimation = new DoubleAnimation();
			doubleAnimation.From = InfoTextDark.ActualWidth;
			doubleAnimation.To = -InfoTextCanvasDark.ActualWidth;
			doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
			doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(60));
			InfoTextDark.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
		}*/

		/*public void InfoText_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				WebClient webClient = new WebClient();
				string nonsenseText = webClient.DownloadString("https://drive.google.com/uc?export=download&id=1WZvXQbUJi1RaGtATzz2m3iEYeM1tezAA");

				InfoText.Text = nonsenseText;
				InfoTextDark.Text = nonsenseText;

				Debug.WriteLine("Nonsense Text has been downloaded and set.");
			}
			catch
			{
				Debug.WriteLine("Nonsense Text had some trouble.");
				InfoText.Text = "Not connected to the internet or the internet connection is weak. Please check your WiFi connection and try again.";
				InfoTextDark.Text = "Not connected to the internet or the internet connection is weak. Please check your WiFi connection and try again.";
			}

			if (InfoText.ActualWidth > InfoTextCanvas.ActualWidth)
			{
				Application.Current.Dispatcher.BeginInvoke(new Action(() =>
				{
					AnimateScroll();
				}));
			}

			if (InfoTextDark.ActualWidth > InfoTextCanvasDark.ActualWidth)
			{
				Application.Current.Dispatcher.BeginInvoke(new Action(() =>
				{
					AnimateScrollDark();
				}));
			}
		}*/
	}
}
