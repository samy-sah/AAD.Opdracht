using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AAD.AfspraakBeheer.Wpf
{
    class AgendaNaarBrushValue : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			Brush kleur = null;
			switch ((AAD.AfspraakBeheer.Data.AgendaSoort)value)
			{
				case Data.AgendaSoort.Student:
					kleur = Brushes.DarkSlateBlue;
					break;
				case Data.AgendaSoort.CEO:
					kleur = Brushes.Goldenrod;
					break;
				default:
					return Binding.DoNothing;
			}
			return kleur;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
