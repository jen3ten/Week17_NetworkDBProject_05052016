using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Week17_NetworkDBProject_05052016.Models
{
    [MetadataType(typeof(RatingAbove4Buddy))]
    public partial class vwRatingsAbove4
    {

    }

    sealed class RatingAbove4Buddy
    {
        public int ShowID { get; set; }
        public int NetworkID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public Nullable<decimal> Rating { get; set; }
        public string Photo { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

    }
}