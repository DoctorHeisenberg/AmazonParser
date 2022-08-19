using MusConv.Models;
using MusConv.Services.Interfaces;
using System.Threading.Tasks;

namespace MusConv.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IMusicService _musicService;

        public MainWindowViewModel(IMusicService musicService)
        {
            _musicService = musicService;
        }

        public override void OnInitialize()
        {
            Task.Run(() => Task.FromResult(Playlist = _musicService.GetPlaylist("https://music.amazon.com/playlists/B09D6T7YF6")));
        }

        private Playlist _playlist;
        public Playlist Playlist
        {
            get => _playlist;
            set
            {
                _playlist = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlaylistName));
            }
        }

        public string PlaylistName
        {
            get => Playlist?.PlaylistInfo.Name;
        }
    }
}
