
using KojangTalk.Core;
using System;
using System.Globalization;


namespace KojangTalk
{
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChatAttachmentPopupMenuViewModel basePopup)
                //DataContext = basePopup.Content 를 갖는 VerticalMenu 반환 하고 그것을 Content에 연결한다. 
                return new VerticalMenu { DataContext = basePopup.Content };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
