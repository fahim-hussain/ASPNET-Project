using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class TrackBaseViewModel
    {
        public TrackBaseViewModel()
        {
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        [Required, StringLength(200)]
        [DisplayName("Track Name")]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        [DisplayName("Composer names (comma-separated)")]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [Required, StringLength(200)]
        public string Clerk { get; set; }

        public ICollection<Album> Albums { get; set; }

    }
}