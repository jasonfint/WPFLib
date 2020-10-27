using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF日常例子
{
    [ValueConversion(typeof(Type), typeof(IEnumerable))]
    public sealed class EnumAsArrayConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == null)
            {
                throw new ArgumentNullException("targetType");
            }
            else if (!typeof(IEnumerable).IsAssignableFrom(targetType))
            {
                var MessageFormat = "The interface \"{0}\" does not implemented by \"{1}\".";
                var message = String.Format(MessageFormat, typeof(IEnumerable), targetType);
                throw new ArgumentException(message, "targetType");
            }//if

            var type = value as Type;
            if (type == null)
            {
                return null;
            }//if

            return Enum.GetValues(type);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion IValueConverter Members
    }
}
