using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Garage.Annotations;

namespace Garage.Viewmodel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "", params string[] propertyNames)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            if (propertyNames != null && propertyNames.Length > 0)
                foreach (string name in propertyNames)
                {
                    this.OnPropertyChanged(name);
                }
            return true;
        }
    }
}