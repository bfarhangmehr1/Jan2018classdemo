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
    public class TrackLengthController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public List<ArtistTitle> Artist_ArtistTitle(int TrackCountlimit)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              where x.Tracks.Count() >= TrackCountlimit
                              select new ArtistTitle
                              {
                                  title = x.Title,
                                  artist = x.Artist.Name,
                                  songs = (from y in x.Tracks
                                           select new TracksAndLength
                                           {
                                               songtitle = y.Name,
                                               length = y.Milliseconds / 60000 + ":" +
                                                        (y.Milliseconds % 60000) / 1000
                                     })
                              };

                return results.ToList();
            }
        }

    }
}
