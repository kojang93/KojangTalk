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
    public static class FrameworkElementAnimations  //StoryboardHelper 클래스랑 관련있음 

        //Story board는 페이지의 애니메이션을 정의함
        //프레임워크에 애니메이션을 추가하는 확장 메서드 

    {

        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {


            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            sb.AddFadeIn(seconds); //애니메이션 함수 추가 흐려지는 함수 


            sb.Begin(element);


            element.Visibility = Visibility.Visible;


            await Task.Delay((int)(seconds * 1000));
        }




        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {

            var sb = new Storyboard();


            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);


            sb.AddFadeOut(seconds); //흐려지지 않는 함수 


            sb.Begin(element);


            element.Visibility = Visibility.Visible;


            await Task.Delay((int)(seconds * 1000));
        }




        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            Console.WriteLine("SlideANdFadeOutToLeftAsync");
            var sb = new Storyboard();

            //자기 엘리먼트의 실제 너비를 넘겨준다. 
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

          
            sb.AddFadeOut(seconds);

        
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

         
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
        
            var sb = new Storyboard();
 
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);

           
            sb.AddFadeOut(seconds);

            
            sb.Begin(element);

          
            element.Visibility = Visibility.Visible;
 
            await Task.Delay((int)(seconds * 1000));
        }

    }
}

    


 