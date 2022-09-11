using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMeetsUI
{
	/// <summary>
	/// The design-time data for a <see cref="MenuViewModel"/>
	/// </summary>
	public class MenuDesignModel : MenuViewModel
	{
		#region Singleton

		/// <summary>
		/// A single instance of the design model
		/// </summary>
		public static MenuDesignModel Instance => new MenuDesignModel();

		#endregion

		#region Constructor

		/// <summary>
		/// Default Constructor
		/// </summary>
		public MenuDesignModel()
		{
			Items = new List<MenuItemViewModel>(new[]
			{
				new MenuItemViewModel { Text = "Design time header..." }
			});
		}

		#endregion
	}
}
