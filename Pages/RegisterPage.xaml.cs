using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace KojangTalk
{
    

    public partial class RegisterPage : BasePage<LoginViewModel>, IHavePassword //LoginViewModel을 BasePage에서 관리하는 이유는 무엇인가?
        //IHavePassword 인터페이스 구현 
    {
        public RegisterPage()
        {
            Console.WriteLine("Register Page");
            InitializeComponent();

          
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
     
    }
}
