using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespace
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
  public  class AlbumTracksCoutroller
    {
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public List<ArtistTitle> Album_GetTitleAndArtist(int TrackCountlimit)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              where x.Tracks.Count() >= TrackCountlimit
                              select new ArtistTitle
                              {
                                  title = x.Title,
                                  artist = x.Artist.Name,
                                  songsTrack = (from y in x.Tracks
                                           select new TracksAndLength
                                           {
                                               Songtitle = y.Name,
                                               length = y.Milliseconds
                                           }).ToList()
                              };
                return results.ToList();
            }
        }
    }
}
