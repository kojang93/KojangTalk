using System;

using System.Globalization;

using System.Windows;

namespace KojangTalk
{
    public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {

        //value DateTimeOffset형 
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter != null)
                 return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            else
                 return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
