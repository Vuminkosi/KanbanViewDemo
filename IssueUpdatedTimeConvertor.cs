using System;
using System.Globalization;

namespace DraggableControlsDemo
{
    public class IssueUpdatedTimeConvertor : BaseValueConvertor<IssueUpdatedTimeConvertor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTime)value;

            //if it is not read
            if (time == DateTime.MinValue)
                //Show nothing
                return string.Empty;
            // if it is today
            if (time.Date == DateTime.Now.Date)
                // return just time
                return $"Updated {time.ToString("HH:mm")}";

            if (time.Date.Year == DateTime.Now.Year)
                // return just time
                return $"Updated {time.ToLocalTime().ToString("dddd, dd MMMM")}";

            // otherwise return a full date
            return $"Updated {time.ToLocalTime().ToString("dddd, dd MMMM yyyy")}";


        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
