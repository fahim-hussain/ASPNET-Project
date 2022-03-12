using S2021A6FH.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {

        public string Biography { get; set; }

        public int AlbumsCount { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}