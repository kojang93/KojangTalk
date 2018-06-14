//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;

//namespace KojangTalk
//{
//    class PasswordBoxProperties
//    {



//이것은 Attached Property 사용하지 않았을때
        

//        public static readonly DependencyProperty MonitorPasswordProperty =
//           DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

//        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            var passwordBox = (d as PasswordBox);

//            if(passwordBox == null)
//            {
//                return;
//            }

//            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

//            if((bool)e.NewValue)
//            {
//                SetHasText(passwordBox);
//                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
//            }
//        }

//        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
//        {
//            SetHasText((PasswordBox)sender);
//        }

//        private static void SetMonitorPassword(PasswordBox element, bool value)
//        {
//            element.SetValue(MonitorPasswordProperty, value);
//        }

//        public static bool GetMonitorPassword(PasswordBox element)
//        {
//            return (bool)element.GetValue(MonitorPasswordProperty);
//        }



//   /// <summary>
//   /// //////////////////////////////////////////////////////////////////
//   /// </summary>

//        public static readonly DependencyProperty HasTextProperty = 
//             DependencyProperty.RegisterAttached("HadText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

//        private static void  SetHasdText(PasswordBox element)
//        {
//            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
//        }

//        public static bool GetHadText(PasswordBox element)
//        {
//           return (bool)element.GetValue(HasTextProperty);
//        }

//    }
//}
