using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DraggableControlsDemo.Models;

namespace DraggableControlsDemo.Converters
{
    public class IssuesFilterConvertor : BaseValueConvertor<IssuesFilterConvertor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not null && value is ObservableCollection<IssueModel> issues && parameter is string param && !string.IsNullOrWhiteSpace(param))
            {
                if (Enum.TryParse<IssueStatus>(param, true, out var issueStatus))
                {
                    return new ObservableCollection<IssueModel>(issues.Where(x => x.Status == issueStatus).OrderByDescending(x => x.StatusChangedDate));
                }
            }
            return default;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
