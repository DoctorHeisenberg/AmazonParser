using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MusConv.Models;
using MusConv.Services;
using MusConv.Services.Interfaces;
using MusConv.ViewModels;
using MusConv.Views;

namespace MusConv
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = AvaloniaLocator.CurrentMutable.GetService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        public override void RegisterServices()
        {
            base.RegisterServices();
            AvaloniaLocator.CurrentMutable.Bind<IMusicService>().ToSingleton<MusicService>();
            AvaloniaLocator.CurrentMutable
                .Bind<MainWindowViewModel>()
                .ToLazy(() => new MainWindowViewModel(AvaloniaLocator.Current.GetService<IMusicService>()));
        }
    }
}
