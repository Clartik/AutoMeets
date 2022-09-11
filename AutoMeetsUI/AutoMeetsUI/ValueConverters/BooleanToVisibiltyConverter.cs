using System;
using System.Globalization;
using System.Windows;

namespace AutoMeetsUI
{
	/// <summary>
	/// A converter that takes in a boolean and returns a <see cref="Visibility"/>
	/// </summary>
	public class BooleanToVisibiltyConverter : BaseValueConverter<BooleanToVisibiltyConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (parameter == null)
				return (bool)value ? Visibility.Hidden : Visibility.Visible;
			else
				return (bool)value ? Visibility.Visible : Visibility.Hidden;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
