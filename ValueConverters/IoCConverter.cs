
using KojangTalk.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //스트링 타입을 IOC컨테이너에서의 서비스로 바꾼다.
    class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           switch ((string)value)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Kernel.Get<ApplicationViewModel>();

                    
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
