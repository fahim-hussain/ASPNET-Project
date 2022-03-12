using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Models
{
    public class ArtistAddFormViewModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Artist name or stage name")]
        public string Name { get; set; }

        [DisplayName("If applicable, Artist Birth Name")]
        public string BirthName { get; set; }

        [Required]
        [DisplayName("Birth date, or start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        [Required]
        [DisplayName("URL to artist Photo")]
        public string UrlArtist { get; set; }

        public string Executive { get; set; }

        public string Genre { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Biography { get; set; }

        [DisplayName("Artist's primary genre")]
        public SelectList ArtistGenreList { get; set; }
        public ArtistAddFormViewModel()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }
    }
}