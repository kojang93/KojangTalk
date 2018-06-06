
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KojangTalk
{
  
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool> //bool type의 프포퍼티를 나타냄?
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) //프로퍼티 변경이 발생했을때 어떻게 처리할 것이낙 
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null)
                return;
            
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if((bool)e.NewValue) //새로 변경된 값이 참이면 
            {
                
                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
          public static void SetValue(DependencyObject sender)
          {
            Console.WriteLine("HasText Property Setvalue");
               SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0); //상속받은 함수 
          }
      
    }
}
