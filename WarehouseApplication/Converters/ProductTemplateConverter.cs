using System;
using System.Globalization;
using System.Windows.Data;
using WarehouseApplication.Models;

namespace WarehouseApplication.Converters
{
    public class ProductTemplateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string id = (string)values[0];
            string name = (string)values[1];
            return new ProductTemplate(id, name);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            ProductTemplate template = (ProductTemplate)value;
            return new object[] { template.Id, template.Name };
        }
    }
}
