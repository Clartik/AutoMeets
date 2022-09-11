using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	/// <summary>
	/// A view model for the Sunday Setup Popup Menu
	/// </summary>
	public class SundaySetupPopupMenuViewModel : BasePopupViewModel
	{
		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SundaySetupPopupMenuViewModel()
		{
			Content = new MenuViewModel
			{
				Items = new List<MenuItemViewModel>(new[]
				{
					new MenuItemViewModel { Text = "Please Setup This Week's Class Schedule." }
				})
			};
		}

		#endregion
	}
}
