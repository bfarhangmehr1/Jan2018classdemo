using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<ClientPlaylist> Playlist_ClientPlaylist(int trackcountlimit)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Playlists
                              where x.PlaylistTracks.Count() > trackcountlimit
                              select new ClientPlaylist
                              {
                                  playlist = x.Name,
                                  songs = from y in x.PlaylistTracks
                                           select new TracksAndGenre
                                           {
                                               songtitle = y.Track.Name,
                                               songgenre = y.Track.Genre.Name,
                                           }
                              };
                return results.ToList();
            }
        }
    }
}
