using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace KojangTalk
{
    public partial class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {


        #region Private Member

        private VM mViewModel;

        #endregion


        #region public properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;


        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;


        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                    return;
                mViewModel = value;
                this.DataContext = mViewModel; //ViewModel이 새로 연결되면 DataContext에 연결

            }
        }

        #endregion


        public BasePage()
        {

            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;


            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM(); //자식 ViewModel
        }

        private async void BasePage_Loaded(object sedner, System.Windows.RoutedEventArgs e)
        {

            await AnimatedIn();

        }

        public async Task AnimatedIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;


            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:  //이페이지에는 SlideAndFadeInFromRight 애니메이션을 적용한다. 


                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;

            }
        }

        public async Task AnimateOut()
        {
            // Make sure we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }

    }
}
