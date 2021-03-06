﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KojangTalk
{

    /// <summary>
    /// ////////
    /// </summary>
    public class BooleanToVisibilityGoneConverter : BaseValueConverter<BooleanToVisibilityGoneConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("value " + nameof(value));
            if (parameter == null)
            {
               
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
             
            }            
            else
            {
              
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
              

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
