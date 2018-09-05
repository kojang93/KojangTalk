using System;

using System.Globalization;

using System.Windows;

namespace KojangTalk
{
   public class SentByMeToBackgroundConverter : BaseValueConverter<SentByMeToBackgroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.FindResource("VeryLightGreenBrush") : Application.Current.FindResource("ForegroundLightBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
