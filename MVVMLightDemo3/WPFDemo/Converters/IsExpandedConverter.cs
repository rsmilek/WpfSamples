using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFDemo.ViewModel;

namespace WPFDemo.Converters
{
    public class IsExpandedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Implement logic to combine values from multiple sources and return a result
            // For example, check a property of the data item and combine it with IsExpanded
            if (values.Length == 2 && values[0] is NodeMvvmViewModel dataItem && values[1] is bool isItemExpanded)
            {
                return dataItem.IsExpanded || isItemExpanded;
                //return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
