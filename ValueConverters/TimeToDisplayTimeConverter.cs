using System;

using System.Globalization;

namespace KojangTalk
{
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {

        //value DateTimeOffset형 
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DateTimeOffset을 String형으로 변환한다. 
             
            var time = (DateTimeOffset)value;

            //현재 날짜와 동일하다면? 시,분 표시 
            if (time.Date == DateTimeOffset.UtcNow.Date) 
            
                return time.ToLocalTime().ToString("HH:mm");

            //오늘 날짜와 동일하지 않다면? 년도 까지 같이 표시
            return time.ToLocalTime().ToString("HH:mm, MMM yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
