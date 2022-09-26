﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace DraggableControlsDemo
{
    public abstract class BaseValueConvertor<T> : MarkupExtension, IValueConverter
         where T : class, new()
    {
 
        private static T? mConvertor = default;
 
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConvertor ??= new T();
        }
          
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

       
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        
    }
}
