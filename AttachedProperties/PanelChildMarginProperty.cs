
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KojangTalk
{
  
    
        public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
        {
            public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
            //패널을 가져온다. 
                var panel = (sender as Panel);

              
                panel.Loaded += (s, ee) =>
                {
                 
                    foreach (var child in panel.Children)
                     // 지정된 값을 panel 마진에 추가한다. 
                        (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
                };
            }
        }

    

}
