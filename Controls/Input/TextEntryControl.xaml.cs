

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace KojangTalk
{
    /// <summary>
    /// TextEntryControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

       
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));


        public TextEntryControl()
        {
            InitializeComponent();
            
        }


        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
               
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }
    }
}
