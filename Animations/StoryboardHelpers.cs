using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace KojangTalk
{


    public static class StoryboardHelpers //애니메이션 함수들 관리하는 곳
    {
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
          
            var animation = new ThicknessAnimation  //굵기 애니메이션 
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),  //애니메이션 구동시간 
                From = new Thickness(offset, 0, -offset, 0), //두께 시작점
                To = new Thickness(0),                 //두께 최종
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin")); //Margin 프로퍼티에 애니메이션을 적용한다. 

          
            storyboard.Children.Add(animation);
        }

     

         
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
          
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

          
            storyboard.Children.Add(animation);
        }

    
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
         
            var animation = new DoubleAnimation  //Double형 변수  변화 애니메이션
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity")); // 투명도에 애니메이션을 적용시킨다. 

       
            storyboard.Children.Add(animation);
        }



    
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
           
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
    
            storyboard.Children.Add(animation);
        }
    }


}
