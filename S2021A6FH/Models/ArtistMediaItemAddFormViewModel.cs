using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class ArtistMediaItemAddFormViewModel
    {
        [Required]
        [DisplayName("Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [DisplayName("Media upload")]
        [DataType(DataType.Upload)]
        public string MediaUpload { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }
    }
}