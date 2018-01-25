using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespace
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_List()
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Tracks.OrderBy(x => x.Name).ToList();
            }
        }
        public Track Tracks_Get(int trackid)
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Tracks.Find(trackid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Tracks_GetByAlbumID( int albumid)
        {
            //create and transaction instance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Tracks.Where( x => x.AlbumId==albumid).Select( x => x).ToList();
            }
        }
    }
}