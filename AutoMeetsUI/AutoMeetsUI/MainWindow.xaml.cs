using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new WindowViewModel(this);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;

			Hide();

			base.OnClosing(e);
		}

		private void AppWindow_Deactivated(object sender, EventArgs e)
		{
			// Show overlay if we lose focus
			(DataContext as WindowViewModel).DimmableOverlayVisible = true;
		}

		private void AppWindow_Activated(object sender, EventArgs e)
		{
			// Hide overlay if we are focused
			(DataContext as WindowViewModel).DimmableOverlayVisible = false;
		}

		private void AppWindow_ContentRendered(object sender, EventArgs e)
		{
			var defaultViewModel = new DefaultViewModel();

			Dispatcher.BeginInvoke(new Action(() =>
			{
				defaultViewModel.TimeScan();
				//defaultViewModel.UpdateHelpText();
			}), DispatcherPriority.Background);
		}
	}
}
