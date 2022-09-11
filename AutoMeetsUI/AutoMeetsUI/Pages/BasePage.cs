using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AutoMeetsUI
{
	/// <summary>
	/// The base page for all pages to gain base functionality
	/// </summary>
	public class BasePage : UserControl
	{
		#region Public Properties

		/// <summary>
		/// The animation to play when the page is first loaded
		/// </summary>
		public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromBottom;

		/// <summary>
		/// The animation to play when the page is unloaded
		/// </summary>
		public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToTop;

		/// <summary>
		/// The time any slide animation takes to complete
		/// </summary>
		public float SlideSeconds { get; set; } = 0.4f;

		/// <summary>
		/// A flag to indicate if this page should animate out on load.
		/// Useful for when we are moving the page to another frame
		/// </summary>
		public bool ShouldAnimateOut { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Contructor
		/// </summary>
		public BasePage()
		{
			// Don't bother animating in design time
			if (DesignerProperties.GetIsInDesignMode(this))
				return;

			// If we are animating in, hide to begin with
			if (PageLoadAnimation != PageAnimation.None)
				Visibility = Visibility.Collapsed;

			// Listen out for the page loading
			Loaded += BasePage_LoadedAsync;
		}

		#endregion

		#region Animation Load / Unload

		/// <summary>
		/// Once the page is loaded, perform any required animation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
		{
			// If we are setup to animate out on load
			if (ShouldAnimateOut)
				// Animate out the page
				await AnimateOutAsync();
			// Otherwise...
			else
				// Animate the page in
				await AnimateInAsync();
		}

		/// <summary>
		/// Animates the page in
		/// </summary>
		/// <returns></returns>
		public async Task AnimateInAsync()
		{
			// Make sure we have something to do
			if (PageLoadAnimation == PageAnimation.None)
				return;

			switch (PageLoadAnimation)
			{
				case PageAnimation.None:
					break;
				case PageAnimation.SlideAndFadeInFromBottom:
					// Start the animation
					await this.SlideAndFadeInFromBottomAsync(SlideSeconds, height: (int)Application.Current.MainWindow.Height);
					break;
				case PageAnimation.SlideAndFadeOutToTop:
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Animates the page out
		/// </summary>
		/// <returns></returns>
		public async Task AnimateOutAsync()
		{
			// Make sure we have something to do
			if (PageUnloadAnimation == PageAnimation.None)
				return;

			switch (PageUnloadAnimation)
			{
				case PageAnimation.None:
					break;
				case PageAnimation.SlideAndFadeOutToTop:
					// Start the animation
					await this.SlideAndFadeOutToTopAsync(SlideSeconds);
					break;
				case PageAnimation.SlideAndFadeInFromBottom:
					break;
				default:
					break;
			}
		}

		#endregion
	}

	/// <summary>
	/// A base page with added ViewModel support
	/// </summary>
	public class BasePage<VM> : BasePage
		where VM : BaseViewModel, new()
	{
		#region Private Members

		/// <summary>
		/// The View Model associated with the page
		/// </summary>
		private VM mViewModel;

		#endregion

		#region Public Properties

		/// <summary>
		/// The View Model associated with the page
		/// </summary>
		public VM ViewModel
		{
			get => mViewModel;
			set
			{
				// If nothing has changed, return
				if (mViewModel == value)
					return;

				// Update the value
				mViewModel = value;

				// Set the data context for this page
				DataContext = mViewModel;
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Default Contructor
		/// </summary>
		public BasePage() : base()
		{
			// Create a default view model
			ViewModel = new VM();
		}

		#endregion
	}
}
