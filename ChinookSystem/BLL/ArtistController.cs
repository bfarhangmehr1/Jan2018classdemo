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
   public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artists_List()
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Artists.OrderBy(x => x.Name).ToList();
            }
        }
        public Artist  Artists_Get( int artistid)
        {
            //create and transacoion ijnstance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Artists.Find(artistid);
            }
        }
    }
}
