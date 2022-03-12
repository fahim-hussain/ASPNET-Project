using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Models
{
    public class AlbumAddViewModel
    {
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(200)]
        public string UrlAlbum { get; set; }

        [Required]
        public string Genre { get; set; }

        public string ArtistName { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Summary { get; set; }

        [StringLength(100)]
        public string Coordinator { get; set; }

        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Track> Tracks { get; set; }
    }
}