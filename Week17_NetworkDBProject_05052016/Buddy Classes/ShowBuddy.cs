using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week17_NetworkDBProject_05052016.Models
{
    [MetadataType(typeof(ShowBuddy))]
    public partial class Show
    {

    }

    sealed class ShowBuddy
    {
        public int ShowID { get; set; }
        public int NetworkID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.#}")]
        public Nullable<decimal> Rating { get; set; }
        public string Photo { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

    }

}