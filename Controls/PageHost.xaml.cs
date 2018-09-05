using KojangTalk.Core;
using System;

using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;





namespace KojangTalk
{

    /// <summary>
    /// PageHostxaml.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 이 사용자 정의 컨트롤은 두개의 중첩된 Frame을 소유하고 있다. 
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        #region CurrentPageProperty
        //CurrentPage 라는 AttachedProperty를 정의한다. 
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }


        //의존 프로퍼티 생성한다는데 의존
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));

        #endregion

        #region CurrentPageViewModelProperty

        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }


        //의존 프로퍼티 생성한다는데 의존
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(PageHost), new UIPropertyMetadata());

        #endregion


        #endregion

        #region Constructor


        public PageHost()
        {

            InitializeComponent();


            //이놈의 XAML을 렌더링 하고있는 중이라면?
            if (DesignerProperties.GetIsInDesignMode(this))
            {

                NewPage.Content = IoC.Application.CurrentPage.ToBasePage();
            }
        }

        #endregion

        #region Property Changed Events


        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {

            //DependencyObject는 여기서 PageHost 자신이다. 
            //사실 이런식으로 AttachedProperty를 정의하는것은 좋지 않다. 


            // 현재 페이지의 ApplicationPage Enum 값
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            //pagehost의 frame 두개를 가져온다. 
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;



            //같은 채팅 페이지라면?
            if (newPageFrame.Content is BasePage page && page.ToApplicationPage() == currentPage)
            {

                //VIewModel 만 바꾸고 애니메이션은 실행하지 않는다. 
                page.ViewModelObject = currentPageViewModel;
                return value;
            }


            Console.WriteLine("CurrentPagePropertyChanged");

           

          
            //Content에는 LoginPage 또는 RegisterPage 그자체가 들어가잇음 

            //newPageFrame은 현재 화면에 나타나는 페이지라고 할수 있다. 
            //이것을 oldPageContent 에 저장한다. temp 랑 비슷한것
            var oldPageContent = newPageFrame.Content;

         
            //현재 프레임을 비운다. 
            newPageFrame.Content = null;

            //화면에서 사라지게할 page를 저장한다. 
            oldPageFrame.Content = oldPageContent;// 요놈을 주석처리하면 Content내용의 변동이 없기때문에 Loaded_Async가 호출되지 않는다. 

            //기존에 화면에 나타나는 페이지를 oldPageFrame에 저장하는 이유는 이놈에게 사라지는 애니메이션을 적용시키기 위해서이다. 

            if (oldPageContent is BasePage oldPage)
            {
              
                oldPage.ShouldAnimateOut = true;

              
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                 
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);

                });
            }

            //변경된 page 예를들면 login -> register로 변경되었을때 register 페이지를 newPageFrame.Content에 저장한다. 
            newPageFrame.Content = IoC.Application.CurrentPage.ToBasePage();

            return value;
            //e.Newvalue 는 LoginPage 또는 RegisterPage 그자체라고 할수 있다. 
        }
        #endregion
    }
}
