using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfMvvm.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ((DateTime)value).ToString((parameter as string) ?? "yyyyMMdd");
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string date = value as string;

            if (string.IsNullOrWhiteSpace(date) || date.Length != 8)
                return DependencyProperty.UnsetValue;

            return DateTime.ParseExact(date, ((parameter as string) ?? "yyyyMMdd"), CultureInfo.CurrentCulture);

        }
    }
}
