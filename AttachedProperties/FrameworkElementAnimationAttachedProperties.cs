using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KojangTalk
{
/// <summary>
/// 애니메이션과 관련된 Attached Proeprty 정의 하는 곳 
/// </summary>
/// <typeparam name="Parent"></typeparam>


    //애니메이션에만 적용되는 Attached Property
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool> //애니메이션에 추가되는 기본 Property
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

    
        public bool FirstLoad { get; set; } = true;

        #endregion

        //Base Property에 OnValueUpdated 도 추가햇다. 

        protected Dictionary<WeakReference, bool> mAlreadyLoaded = new Dictionary<WeakReference, bool>();

      
        protected Dictionary<WeakReference, bool> mFirstLoadValue = new Dictionary<WeakReference, bool>();



        public override void OnValueUpdated(DependencyObject sender, object value)//DependencyObject란 여기서 Attached Property 를 부여받은 object라고 할수 있다. 
        {

            Console.WriteLine("OnValueUpdated " + sender);

            if (!(sender is FrameworkElement element)) //Attached Property를 부여받은 sender 를 FrameworkElement로 언박싱한다. 
                return;


            //
            var alreadyLoadedReference = mAlreadyLoaded.FirstOrDefault(f => f.Key.Target == sender);

            var firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);


            if ((bool)sender.GetValue(ValueProperty) == (bool)value && alreadyLoadedReference.Key != null)//값변동이 없고 FirstLoad가 false 이면 어떤 동작도 하지않는다. 
                return; 
            
       
            if (alreadyLoadedReference.Key == null) //처음 로드 되는 것이라면 
            {
                Console.WriteLine("first load");
                var weakReference = new WeakReference(sender);
                mAlreadyLoaded[weakReference] = false;

              
                element.Visibility = Visibility.Hidden;

                RoutedEventHandler onLoaded = null;

                onLoaded = async (ss, ee) =>
                {
                    Console.WriteLine("OnLoaded");
                    element.Loaded -= onLoaded;

                    await Task.Delay(5);

                    firstLoadReference = mFirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);

                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool)value, true);

                    mAlreadyLoaded[weakReference] = true;
                };

                //요소가 배치되고 렌더링 되었을때 onLoaded 이벤트 발생하도록 추가 
                element.Loaded += onLoaded;
            }

            else if (alreadyLoadedReference.Value == false)
                mFirstLoadValue[new WeakReference(sender)] = (bool)value;

            else

                DoAnimation(element, (bool)value, false);
        }

      
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is Image image))
                return;
            if ((bool)value)
                image.TargetUpdated += Image_TargetUpdatedAsync;
            else
                image.TargetUpdated -= Image_TargetUpdatedAsync;
        }


        private async void Image_TargetUpdatedAsync(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            await (sender as Image).FadeInAsync(false);
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            //value 값은 애니며이션 attached property의 참인지 거짓인지 나타내는 값
            if (value)

                // 참이면 왼쪽에서 튀어나옴 생겨남
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //거짓이면 왼족으로 들어감 없어짐
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
        }


    }

    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            //value 값은 애니며이션 attached property의 참인지 거짓인지 나타내는 값
            if (value)

                // 참이면 왼쪽에서 튀어나옴 생겨남
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //거짓이면 왼족으로 들어감 없어짐
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: false);
        }


    }

    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            //value 값은 애니며이션 attached property의 참인지 거짓인지 나타내는 값
            if (value)

                // 참이면 왼쪽에서 튀어나옴 생겨남
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                //거짓이면 왼족으로 들어감 없어짐
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: true);
        }


    }



    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {

            if (value)
            {
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);

            }
        }
    }



    public class AnimatedSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimatedSlideInFromBottomOnLoadProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {

          await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value ? 0 : 0.3f, keepMargin: false);
        }
    }

    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty> //
    {


        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {

            if (value)
            {
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            }
            else
            {
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);

            }
        }
    }

    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty> //
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {

            if (value)
            {
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            }
            else
            {
                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);

            }
        }
    }


}
