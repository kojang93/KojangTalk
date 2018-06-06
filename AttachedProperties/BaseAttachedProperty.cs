using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KojangTalk
{

    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()

    {
        #region Public Events

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion


        #region Properties


        public static Parent Instance {get; private set;} = new Parent();
        #endregion

        #region Attached Property Definitions

       // Value 에 의존하는 의존속성 ValueProperty 정의 
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>),
       new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged))); //ValueProperty, 의존속성의 변화가 일어날때 OnValuePropertyChanged 호출


        //왜 부모 클래스에서 자식클래스 인스턴스 만들어서 하는 것인가?

            //d에는 예를들면 passwordbox 가 오지 

            //처음 초기화 될때 한번 호출됨
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) //프로퍼티 변화가 일어났을때 자식놈의 instance 함수 호추 ㄹ
        {
            Console.WriteLine("띠용" + d);
            Console.WriteLine("호출");
            Instance.OnValueChanged(d, e);
            Instance.ValueChanged(d, e);
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty); //

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion


        #region Event Methods
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { } //자식놈이 재구현 하는 함수 
        #endregion

    }

}