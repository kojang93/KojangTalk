using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KojangTalk
{
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        #region Private Members

       // 부모 border가 처음 load될때 호출됨
        private RoutedEventHandler mBorder_Loaded;

      //bordersize가 변경될때 호출된다. 
        private SizeChangedEventHandler mBorder_SizeChanged;

        #endregion

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
         
            var self = (sender as FrameworkElement);

          
            if (!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            //border = parent
            //self = image
          
            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, self);

          
            mBorder_SizeChanged = (s1, e1) => Border_OnChange(s1, e1, self);

            //새로 변경된 값이 참이면
            if ((bool)e.NewValue)
            {
                border.Loaded += mBorder_Loaded;
                border.SizeChanged += mBorder_SizeChanged;
            }
          //새로 변경된 값이 거짓이면
            else
            {
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeChanged;
            }
        }

     
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
           
            var border = (Border)sender;

         
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

           
            var rect = new RectangleGeometry();

         
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            
            rect.Rect = new Rect(child.RenderSize);

          
            child.Clip = rect;
        }
    }

}