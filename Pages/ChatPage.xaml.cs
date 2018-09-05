using KojangTalk.Core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace KojangTalk
{
    /// <summary>
    /// ChatPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    //ChatMessageListViewModel에 커맨드 정의 해 있다 .
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {

        #region Constructor

        //chagPage 에 연결시킬 ViewModel을 생성자이 매개변수로 념거줌
        public ChatPage() : base()
        {
            InitializeComponent();
        }


        //특정 ViewModel을 위한 생성자
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion 


        //BasePage에 있는 함수 Override 한것 
        //Viewmodel 교체될때마다 호출됨
        protected override void OnViewModelChanged()
        {
            
            if (ChatMessageList == null)
                return;

            //애니메이션 효과 
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);


            MessageText.Focus();
        }

        private void MessageText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var textbox = sender as TextBox;
            //엔터키를 눌렀을때
            if(e.Key == Key.Enter)
            {
                //커트롤 키를 동시에 눌렀을때 
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    var index = textbox.CaretIndex;

                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    textbox.CaretIndex = index + Environment.NewLine.Length;



                    e.Handled = true;
                }
                else
                {
                    ViewModel.Send();
                }
                e.Handled = true;
            }
        }
    }
}
