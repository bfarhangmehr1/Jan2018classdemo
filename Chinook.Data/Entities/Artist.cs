using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Chinook.Data.Entities
{
    [Table("Artist")]
   public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [StringLength(120, ErrorMessage ="Artist Name has maximum of 120 characters")]       
        public string Name { get; set; }

        //navigational properties
        public virtual ICollection<Album> Albums { get; set; }
    }
}
