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
    public static class PageAnimations  //StoryboardHelper 클래스랑 관련있음 

        //Story board는 페이지의 애니메이션을 정의함


    {
       
            public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
            {

              
                var sb = new Storyboard();    
            
                sb.AddSlideFromRight(seconds, page.WindowWidth);
            
                sb.AddFadeIn(seconds); //애니메이션 함수 추가 흐려지는 함수 

                
                sb.Begin(page);

               
                page.Visibility = Visibility.Visible;

             
                await Task.Delay((int)(seconds * 1000));
            }

          


            public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
            {
              
                var sb = new Storyboard();

              
                sb.AddSlideToLeft(seconds, page.WindowWidth);

              
                sb.AddFadeOut(seconds); //흐려지지 않는 함수 

              
                sb.Begin(page);

              
                page.Visibility = Visibility.Visible;

             
                await Task.Delay((int)(seconds * 1000));
            }
        }

    }


 