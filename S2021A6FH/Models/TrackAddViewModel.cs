using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class TrackAddViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [StringLength(200)]
        public string Clerk { get; set; }

        public ICollection<Album> Albums { get; set; }

        public string AlbumName { get; set; }

        public int AlbumId { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
}