using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class BookViewModel
    {
        
        [Required]
        public int bok_id { get; set; }
        [Required]
        public String bok_titill  { get; set; }
        [Required]
        public String fornafn_hofundar { get; set; }
        [Required]
        public String eftirnafn_hofundar { get; set; }
        [Required]
        public DateTime utgafudagur { get; set; }
        [Required]
        public String ISBN { get; set; }
    

    }
}
