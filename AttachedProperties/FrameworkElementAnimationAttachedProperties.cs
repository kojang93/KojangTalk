using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KojangTalk
{
  /// <summary>
 
  /// </summary>
  /// <typeparam name="Parent"></typeparam>
  



    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool> //애니메이션에 추가되는 기본 Property
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

    
        public bool FirstLoad { get; set; } = true;

        #endregion

        //Base Property에 OnValueUpdated 도 추가햇다. 
        
        public override void OnValueUpdated(DependencyObject sender, object value)//DependencyObject란 여기서 Attached Property 를 부여받은 object라고 할수 있다. 
        {
            Console.WriteLine("sender " + sender);
            if (!(sender is FrameworkElement element)) //Attached Property를 부여받은 sender 를 FrameworkElement로 언박싱한다. 
                return;

            

            if (sender.GetValue(ValueProperty) == value && !FirstLoad)//값변동이 없고 FirstLoad가 false 이면 어떤 동작도 하지않는다. 
                return; 
            
       
            if (FirstLoad) //처음 로드 되는 것이라면 
            {
            
                RoutedEventHandler onLoaded = null;

                onLoaded = (ss, ee) =>
                {
              
                    element.Loaded -= onLoaded;

                
                    DoAnimation(element, (bool)value);

                
                    FirstLoad = false;
                };

                //요소가 배치되고 렌더링 되었을때 onLoaded 이벤트 발생하도록 추가 
                element.Loaded += onLoaded;
            }
            else
          
                DoAnimation(element, (bool)value);
        }

      
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }

  
    /// <summary>
    /// 
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            //value 값은 애니며이션 attached property의 참인지 거짓인지 나타내는 값
            if (value)
                
                // 참이면 왼쪽에서 튀어나옴 생겨남
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //거짓이면 왼족으로 들어감 없어짐
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }


    }
}
