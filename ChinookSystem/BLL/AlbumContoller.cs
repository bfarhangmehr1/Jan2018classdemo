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
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_List()
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Albums.OrderBy(x => x.Title).ToList();
            }
        }
        public Album Albums_Get(int albumid)
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Albums.Find(albumid);
            }
        }
    }
}
