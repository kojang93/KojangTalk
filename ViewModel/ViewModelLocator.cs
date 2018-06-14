using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //Ioc 컨테이너로부터 꺼내온 View model을 xaml files에 사용하기위해 위치시킨다
    public class ViewModelLocator
    {

        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
