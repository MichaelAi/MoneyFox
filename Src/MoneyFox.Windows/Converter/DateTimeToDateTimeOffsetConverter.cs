using System;
using Windows.UI.Xaml.Data;

namespace MoneyFox.Windows.Converter {
    public class DateTimeToDateTimeOffsetConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            try {
                var date = System.Convert.ToDateTime(value);
                return new DateTimeOffset(date);
            }
            catch (ArgumentOutOfRangeException) {
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            try {
                var dto = (DateTimeOffset) value;
                return dto.DateTime;
            }
            catch (Exception) {
                return DateTime.MinValue;
            }
        }
    }
}