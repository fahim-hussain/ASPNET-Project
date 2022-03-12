using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Models
{
    public class AlbumAddFormViewModel
    {

        [Required]
        [StringLength(100)]
        [DisplayName("Album Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("URL to album image (cover art)")]
        public string UrlAlbum { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Album summary")]
        public string Summary { get; set; }

        public string ArtistName { get; set; }

        public int ArtistId { get; set; }

        [DisplayName("Album's primary genre")]
        public SelectList AlbumGenreList { get; set; }

        public AlbumAddFormViewModel()
        {
            ReleaseDate = DateTime.Now.AddYears(-20);
        }

    }
}