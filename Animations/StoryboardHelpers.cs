using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace KojangTalk
{
    //스토리보드에 확장함수 추가해주는 함수 

    public static class StoryboardHelpers //애니메이션 함수들 관리하는 곳
    {



        public static void AddSlideFromBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
         

            var animation = new ThicknessAnimation  //굵기 애니메이션 
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                To = new Thickness(0),
              
                DecelerationRatio = decelerationRatio
            };


            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin")); //Margin 프로퍼티에 애니메이션을 적용한다. 


            storyboard.Children.Add(animation);

        }

        public static void AddSlideToBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
         

            var animation = new ThicknessAnimation  //굵기 애니메이션 
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                DecelerationRatio = decelerationRatio
            };


            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin")); //Margin 프로퍼티에 애니메이션을 적용한다. 

            storyboard.Children.Add(animation);

        }

        public static void AddSlideFromTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
          
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

          
            storyboard.Children.Add(animation);
        }

     
        public static void AddSlideToTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
          
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

          
            storyboard.Children.Add(animation);
        }


        //오른쪽에서 튀어나옴

        /// <summary>
        /// /
        /// </summary>
        /// <param name="storyboard"></param>  애니메이션을 추가할 스토리보드 
        /// <param name="seconds"></param>  애니메이션 지속되는 시간
        /// <param name="offset"></param> 이동거리 
        /// <param name="decelerationRatio"></param>  속도 감소율
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin= true)
        {
           
            var animation = new ThicknessAnimation  //굵기 애니메이션 
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin")); //Margin 프로퍼티에 애니메이션을 적용한다. 

          
            storyboard.Children.Add(animation);



        }

        //왼쪽으로 들어감  
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };


            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));


            storyboard.Children.Add(animation);
        }

        //왼쪽에서 튀어나옴
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset,  bool keepMargin = true, float decelerationRatio = 0.9f)
        {
          
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

          
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

          
            storyboard.Children.Add(animation);
        }

       //오른쪽으로 들어감
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, bool keepMargin=true, float decelerationRatio = 0.9f)
        {

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };


            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));


            storyboard.Children.Add(animation);
        }

       


        /// <summary>
     
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
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
