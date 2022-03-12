using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class ArtistMediaItemAddViewModel
    {
        public ArtistMediaItemAddViewModel()
        {
            Timestamp = DateTime.Now;

            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        [Required]
        public string StringId { get; set; }

        [Required]
        public string Caption { get; set; }

        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public DateTime Timestamp { get; set; }

        public string ContentType { get; set; }

        [Required]
        public HttpPostedFileBase MediaUpload { get; set; }
    }
}