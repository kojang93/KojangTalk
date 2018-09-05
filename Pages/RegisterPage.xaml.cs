using KojangTalk.Core;
using System;

using System.Security;




namespace KojangTalk
{
    

    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword //LoginViewModel을 BasePage에서 관리하는 이유는 무엇인가?
        //IHavePassword 인터페이스 구현 
    {
        public RegisterPage()
        {
            InitializeComponent();      
        }


        public RegisterPage(RegisterViewModel specificViewModel) : base(specificViewModel)      
        {         
            InitializeComponent();
        }


        public SecureString SecurePassword => PasswordText.SecurePassword;
     
    }
}
