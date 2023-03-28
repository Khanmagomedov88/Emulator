using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Markup;

namespace Helpers
{
    public class RelativeToAbsolutePathConverter : IValueConverter
    {
        public static readonly string BaseFolder = AppDomain.CurrentDomain.BaseDirectory;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = (string)value;
            if (string.IsNullOrWhiteSpace(name))
                return null;
            //return File.ReadAllBytes(Path.Combine(BaseFolder, name));
            return Path.Combine(BaseFolder, name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        private RelativeToAbsolutePathConverter() { }
        public static RelativeToAbsolutePathConverter Instance { get; } = new RelativeToAbsolutePathConverter();
    }

    [MarkupExtensionReturnType(typeof(RelativeToAbsolutePathConverter))]
    public class RelativeToAbsolutePathExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return RelativeToAbsolutePathConverter.Instance;
        }
    }
}
