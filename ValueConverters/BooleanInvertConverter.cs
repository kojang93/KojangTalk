using System;
using System.Globalization;

namespace KojangTalk
{
   /// <summary>
   /// boolean 값 반대로 convert함
   /// </summary>
    public class BooleanInvertConverter : BaseValueConverter<BooleanInvertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}