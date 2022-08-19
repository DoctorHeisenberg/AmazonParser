using Avalonia.Controls;
using MusConv.ViewModels;

namespace MusConv.Views
{
    public class BaseWindow<T> : Window
       where T : ViewModelBase
    {
        public T ViewModel => DataContext as T;

        public override void Show()
        {
            base.Show();

            ViewModel.OnAppeared();
        }
    }
}
