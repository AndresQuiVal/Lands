using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewsModels
{
    #region Libraries
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }
            backingField = value;
            OnPropertyChanged(propertyName);
        }
        #endregion

        //part 2

        //public static void SetValue<T>(ref T backingField, T _value, Object _this, T prop)
        //{
        //    if (backingField != _value) //password - Password
        //    {
        //        backingField = _value;
        //        PropertyChanged?.Invoke(
        //        _this,
        //        new PropertyChangedEventHandler(nameof(prop)))
        //    }
        //}
    }
}
