using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace licencjatFrontend.Helpers
{
    public class DataGridHeightHelper : IValueConverter
    {
        private const double RowHeight = 35;
        private const double HeaderHeight = 40;
        private const double MaxVisibleRows = 10; 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                int visibleRows = Math.Min(count, (int)MaxVisibleRows);
                return HeaderHeight + visibleRows * RowHeight;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
