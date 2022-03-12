using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class AlbumWithDetailViewModel : AlbumBaseViewModel
    {
        [Required]
        [DisplayName("Number of tracks on this album")]
        public int TracksCount { get; set; }

        [Required]
        [DisplayName("Number of Artists on this album")]
        public int ArtistsCount { get; set; }
    }
}