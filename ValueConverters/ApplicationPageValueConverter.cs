
using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //페이지마다 enum으로 정의하고 enum의 값에 따라 컨버트를 따로해서 불러온다. 
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("ApplicationPageValueConverter");
     
           switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Register:
                    return new RegisterPage();

                case ApplicationPage.Chat:
                    return new ChatPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
