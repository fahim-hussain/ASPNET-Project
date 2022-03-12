using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class AlbumBaseViewModel
    {
        public AlbumBaseViewModel()
        {
            ReleaseDate = DateTime.Now;
            Artists = new List<Artist>();
            Tracks = new List<Track>();
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Album name")]
        public string Name { get; set; }

        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [DisplayName("Album cover art")]
        public string UrlAlbum { get; set; }

        [Required]
        [DisplayName("Album's primary genre")]
        public string Genre { get; set; }

        // User name who looks after the album
        [Required, StringLength(200)]
        public string Coordinator { get; set; }

        [DisplayName("Album summary")]
        public string Summary { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}