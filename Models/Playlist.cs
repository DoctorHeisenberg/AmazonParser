using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusConv.Models
{
    public class Playlist
    {
        public PlaylistInfo PlaylistInfo { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
    }
}
