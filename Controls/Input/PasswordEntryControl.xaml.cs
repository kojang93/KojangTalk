﻿

using KojangTalk.Core;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace KojangTalk
{
    /// <summary>
    /// TextEntryControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

       
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));


        public PasswordEntryControl()
        {
            InitializeComponent();
            
        }


        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
               
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
         
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }

      
        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
         
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

      
        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }
    }
}
