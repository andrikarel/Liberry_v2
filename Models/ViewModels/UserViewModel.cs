using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int vinur_id { get; set; }
        [Required]
        public String fornafn  { get; set; }
        [Required]
        public String eftirnafn  { get; set; }
      
        public String heimilisfang {get; set; }
        [Required]
        public String netfang { get; set; }
        
        public List<LoanViewModel> lanasafn {get; set;}
      

    }
}