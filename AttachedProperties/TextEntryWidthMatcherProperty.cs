
using System;
using System.Windows;
using System.Windows.Controls;

namespace KojangTalk
{
  
    
        public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
        {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //패널을 가져온다. 
            var panel = (sender as Panel);

        
            SetWidths(panel);

            // Wait for panel to load
            RoutedEventHandler onLoaded = null;

            onLoaded = (s, ee) =>
            {
                // Unhook
                panel.Loaded -= onLoaded;

             
                SetWidths(panel);

               // 자식놈들 loop를 돈다 
                foreach (var child in panel.Children)
                {
                  //자식놈들중 TextEntryControl이 아니면 배제 시킨다. 
                    if (!(child is TextEntryControl control))
                        continue;

                    //주어진 값으로 margin을 추가한다. 
                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        
                        SetWidths(panel);
                    };
                }
            };

           
            panel.Loaded += onLoaded;
        }

       /// <summary>
       /// ///모든 entry control에 대해서 가장 최대값을 기준으로 맞춘다. 
       /// </summary>
       /// <param name="panel"></param>
        private void SetWidths(Panel panel)
        {
           //기준이 될 가장 큰 maxSize 저장 
            var maxSize = 0d;

            
            foreach (var child in panel.Children)
            {
                //TextEnctryControl이 아니면 
                if (!(child is TextEntryControl control))
                    continue;

              
                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

          
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());



            foreach (var child in panel.Children)
            {
              
                if (!(child is TextEntryControl control))
                    continue;

              
                control.LabelWidth = gridLength;
            }

        }
    }



}
