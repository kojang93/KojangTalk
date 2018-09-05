
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace KojangTalk
{
    public  class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
         
            if (!(sender is Control control))
                return;

         
            control.Loaded += (s, se) => control.Focus();
        }
    }

    //textbox 의 경우 특정 bool값이 참이되면 활성화됨(focus 됨)
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            if (!(sender is Control control))
                return;

            if((bool)e.NewValue)
                control.Focus();
            
        }
    }


    // 트정 bool값이 활성화 되었을때 Select 까지됨 textbox 안의 텍스트 선택되므 

    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            if (sender is TextBoxBase control)

            {
                if ((bool)e.NewValue)
                {

                    control.Focus();
                    control.SelectAll();

                }
            }

            if (sender is PasswordBox password)

            {
                if ((bool)e.NewValue)
                {
                    
                    password.Focus();
                    password.SelectAll();

                }
            }

        }
    }
}
