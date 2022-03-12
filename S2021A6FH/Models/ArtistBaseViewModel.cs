using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class ArtistBaseViewModel
    {
        public ArtistBaseViewModel()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        public int Id { get; set; }

        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        [Required, StringLength(100)]
        [DisplayName("Artist name or stage name")]
        public string Name { get; set; }

        // For an individual, a birth name
        [DisplayName("If applicable, artist's birth name")]
        [StringLength(100)]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [DisplayName("Birth date, or start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [DisplayName("Artist photo")]
        public string UrlArtist { get; set; }

        [Required]
        [DisplayName("Artist's primary genre")]
        public string Genre { get; set; }
    }
}