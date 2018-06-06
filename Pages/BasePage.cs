using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace KojangTalk
{
    public partial class BasePage : System.Windows.Controls.Page
    {

        #region public properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;


        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        #endregion


        public BasePage()
        {

            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;


            this.Loaded += BasePage_LoadedAsync;

        }

        private async void BasePage_LoadedAsync(object sedner, System.Windows.RoutedEventArgs e)
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

    }
}
