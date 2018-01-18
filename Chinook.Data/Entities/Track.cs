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
    [Table("Tracks")]
    public class Track
    {
       
       [Key]
        public int TrackId { get; set; }
        [StringLength(200, ErrorMessage = "Track Name has maximum of 200 characters")]
        [Required(ErrorMessage = "Track Name is required.")]
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        [StringLength(220, ErrorMessage = "composer has maximum of 220 characters")]       
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        //nullble
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        //navigational properties
        public virtual Album Albums { get; set; }

    }
}
