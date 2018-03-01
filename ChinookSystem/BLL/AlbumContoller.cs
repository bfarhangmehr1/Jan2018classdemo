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
            //create and transacoion instance of your context class
            using (var context = new ChinookContext())
            {
                // call to linq method not only extension 
                return context.Albums.Find(albumid);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void Albums_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                //staged to be physically placed on the database
                context.Albums.Add(item);
                //physicallly cause the stage itme to be 
                // placed on the database 
                //this is a commit of using transaction
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Albums_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                item.ReleaseLabel = string.IsNullOrEmpty(item.ReleaseLabel) ? null : item.ReleaseLabel;
                //staged to be physically placed on the database
                context.Albums.Add(item);
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(Album item)
        {
            Albums_Delete(item.AlbumId);
          
        }
        public void Albums_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {
                    throw new Exception("Abum does not exists on file.");
                }
                context.Albums.Remove(existing);
                context.SaveChanges();
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> List_AlbumTitles()
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              orderby x.Title
                              select new SelectionList
                              {
                                  IDValueField = x.AlbumId,
                                  DisplayText = x.Title
                              };
                return results.ToList();
            }
        }
    }
}
