using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DraggableControlsDemo
{

    public class NotifyModel : DependencyObject, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = default, string[]? dependancyProperties = default, Action? valueChanged = default)
        {

            if (string.IsNullOrWhiteSpace(propertyName))
                return false;

            if (object.Equals(field, value))
            { return false; }
            field = value;
            OnPropertyChanged(propertyName);

            if (dependancyProperties is null || !dependancyProperties.Any())
                return true;

            foreach (var dependancyPropertyName in dependancyProperties)
                OnPropertyChanged(dependancyPropertyName);

            if (valueChanged is not null)
                valueChanged.Invoke();

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = default)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



    }
}
