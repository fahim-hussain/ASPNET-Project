using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class ArtistWithMediaInfoViewModel : ArtistWithDetailViewModel
    {
        public ArtistWithMediaInfoViewModel()
        {
            MediaItems = new List<ArtistMediaItemBaseViewModel>();
        }

        public IEnumerable<ArtistMediaItemBaseViewModel> MediaItems { get; set; }
    }
}