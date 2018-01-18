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
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [StringLength(160, ErrorMessage = "Title has maximum of 160 characters")]
        // Title is non nullable and needs to put Required...
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        //navigational properties
        public virtual Artist  Artists { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
