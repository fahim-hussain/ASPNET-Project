using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2021A6FH.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {

        public byte[] Audio { get; set; }

        public string AudioContentType { get; set; }
    }
}