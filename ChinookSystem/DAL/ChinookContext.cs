using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Additional namespaces
using Chinook.Data.Entities;
using System.Data.Entity;
#endregion
namespace ChinookSystem.DAL
{

  internal  class ChinookContext:DbContext
    {
        //name holds the name value of web connection string
        public ChinookContext():base ("name=ChinookDB")
        {

        }
        // a referces to each table in the database as a virtual dataset
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    }
}
