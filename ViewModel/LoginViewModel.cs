using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KojangTalk
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties


        public string Email { get; set; } //이메일을 저장하는 프로퍼티 

        private bool login;
        public bool LoginIsRunning {
            get
            {
                return login;
            }

            set
            {
                login = value;
                Console.WriteLine("LoginIs Running Set " + login);
            }
                
                
               } //login커맨드가 실행중인지 나타내는 flag

        #endregion

        #region Commands


        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor


        public LoginViewModel()
        {
            //xaml 에서 command parameter를 Page로 지정하였음 
            Console.WriteLine("LoginViewModel");
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter)); //이벤트 함수 등록
        }

        #endregion


        //login 버튼 눌렀을때 실행 되는 함수 
        //로그인 절차 진행되는동안은 로그인 버튼 안눌리게 해놓을꺼임 

        public async Task Login(object parameter) //파라미터로 넘어 오는것이 page
        {
            Console.WriteLine("Login");
            await RunCommand(() => this.LoginIsRunning, //bool값을 반환하는 람다식 넘겨줌
                
            async () =>
                {
                    Console.WriteLine("Spin");
                    await Task.Delay(5000);

                    var email = this.Email;

                //login page는 IHavePassword 인터페이스 구현되어있음 

                    var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                }
            );

        }

        //플래그가 세팅 되어 있지 않으면 커맨드를 실행하지 않는다. 
        //

    }
}
