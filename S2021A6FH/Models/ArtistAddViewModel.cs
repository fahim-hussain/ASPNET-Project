using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2021A6FH.Models
{
    public class ArtistAddViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string BirthName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}")]
        public DateTime BirthOrStartDate { get; set; }

        [Required]
        public string UrlArtist { get; set; }

        public string Executive { get; set; }

        [Required]
        public string Genre { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Biography { get; set; }

        public IEnumerable<Album> Albums { get; set; }

    }
}