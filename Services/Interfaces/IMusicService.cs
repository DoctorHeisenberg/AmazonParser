using MusConv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusConv.Services.Interfaces
{
    public interface IMusicService
    {
        Playlist GetPlaylist(string url);
    }
}
