using MusConv.Models;
using MusConv.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tmds.DBus;

namespace MusConv.ViewModels
{
    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
    {
        private bool _isInitialized;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnAppeared()
        {
            if (_isInitialized)
                return;

            _isInitialized = true;
            PropertyChanged += ViewModelBase_PropertyChanged;
            OnInitialize();
        }

        private void ViewModelBase_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine();
        }

        public virtual void OnInitialize()
        {

        }
    }
}
