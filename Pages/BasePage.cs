
using KojangTalk.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace KojangTalk
{
    //모든 페이지에 적용할 수 잇는 base page

    public class BasePage : UserControl
    {
        #region Private Member

        private object mViewModel;

        #endregion



        #region Public Properties


        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

       
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

    
        public float SlideSeconds { get; set; } = 0.4f;

     
        public bool ShouldAnimateOut { get; set; }

        public object ViewModelObject
        {
            get =>  mViewModel; 


            //set은 언제 호출되는가?  ChatPage 에서 다른 페이지로 변동 없이 ViewModel 만 변경되었을때 호출된다. 
            set
            {
                Console.WriteLine("VIewModelObject Set");
                if (mViewModel == value)
                    return;

                mViewModel = value;


                //view model changed method를 호출한다. 
                OnViewModelChanged();


                //이 페이지에 data context를 세팅한다. 
                this.DataContext = mViewModel; //ViewModel이 새로 연결되면 DataContext에 연결

            }
        }




        #endregion

        #region Constructor


        public BasePage()

        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

             Loaded += BasePage_LoadedAsync;

          
        }

        #endregion

        #region Animation Load / Unload

     
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
         

            Console.WriteLine("BasePage_LoadedAsync");

            //화면에서 사라지는 애니메이션 실행
            if (ShouldAnimateOut)

                await AnimateOutAsync();

            //화면으로 들어오는 애니메이션 실행
            else

                await AnimateInAsync();
        }

       
        public async Task AnimateInAsync()
        {
            Console.WriteLine("AnimateInAsync"); 
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //page가 Framework 를 상속받은 거기 때문에 확장메서드 사용할 수 있다. 
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
            }
        }

     
        public async Task AnimateOutAsync()
        {
            Console.WriteLine("AnimateOutAsync");
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    
                    //page가 Framework 를 상속받은 거기 때문에 확장메서드 사용할 수 있다. 
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds);

                    break;
            }
        }



        #endregion

        protected virtual void OnViewModelChanged()
        {

        }
    }



    /// <summary>
    /// ////
    /// </summary>
    /// <typeparam name="VM"></typeparam>



    //viewModel을 지원하는 Base page
    public partial class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
       

        #region public properties
       
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }
    
     

        #endregion  

        //사용해야할 특정 viewmodel
        public BasePage() : base()
        {
         
            this.ViewModel = IoC.Get<VM>();//자식 ViewModel

        }

       // 특정 viewmodel을 위한 Constructor
        public BasePage(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else 
                this.ViewModel = IoC.Get<VM>();//자식 ViewModel

        }


    }
}
