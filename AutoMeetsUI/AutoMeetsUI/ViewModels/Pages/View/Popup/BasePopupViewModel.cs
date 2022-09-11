using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	/// <summary>
	/// A view model for any popup menus
	/// </summary>
	public class BasePopupViewModel : BaseViewModel
	{
		#region Public Properties

		/// <summary>
		/// The background color fo the bubble in ARGB value
		/// </summary>
		public string BubbleBackground { get; set; }

		/// <summary>
		/// The alignment of the bubble arrow
		/// </summary>
		public ElementHorizontalAlignment ArrowAlignment { get; set; }

		/// <summary>
		/// The content inside of this popup menu
		/// </summary>
		public BaseViewModel Content { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public BasePopupViewModel()
		{
			// Set default values
			BubbleBackground = "ffffff";
			ArrowAlignment = ElementHorizontalAlignment.Left;
		}

		#endregion
	}
}
