using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class TrackEditFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DisplayName("Clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }
}