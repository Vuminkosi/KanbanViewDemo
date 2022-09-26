using System;
using System.Globalization;

namespace DraggableControlsDemo
{
    public class WindowActualWidthToWidthConvetor : BaseValueConvertor<WindowActualWidthToWidthConvetor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var windowActualWidth = (double)value;
              
            return windowActualWidth - 20;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
