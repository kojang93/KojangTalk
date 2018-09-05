
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
    public static class ApplicationPageHelpers
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            Console.WriteLine("ApplicationPageValueConverter");
     
           switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                case ApplicationPage.Chat:
                    //Converter의 인자인 parameter를 ChatPage의 매개변수로 넘겨준다. Chatpage는 parameter를 가지고 ViewModel로 사용한다. 
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
          
            if (page is ChatPage)
                return ApplicationPage.Chat;

            if (page is LoginPage)
                return ApplicationPage.Login;

            if (page is RegisterPage)
                return ApplicationPage.Register;

         
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
