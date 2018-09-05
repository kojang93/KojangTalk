
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace KojangTalk
{
    //데이터 컨텍스트가 바뀌었을때 스크롤 스크롤을 젤 아래로 내린다. 즉 다른 채팅 선택했을때 스크롤 위치  초기화
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            if (!(sender is ScrollViewer control))
                return;

            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }



        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }


    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            if (!(sender is ScrollViewer control))
                return;

            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }



        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            // 스크롤이 바닥에 가까워지면
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                scroll.ScrollToEnd();
        }
    }

}
