using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	/// <summary>
	/// A view model for a menu
	/// </summary>
	public class MenuViewModel : BaseViewModel
	{
		/// <summary>
		/// The items in this menu
		/// </summary>
		public List<MenuItemViewModel> Items { get; set; }
	}
}
