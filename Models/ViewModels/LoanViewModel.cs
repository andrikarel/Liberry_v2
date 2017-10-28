using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class LoanViewModel
    {
        
        [Required]
        public int vinur_id { get; set; }
        [Required]
        public int bok_id  { get; set; }

        [Required]
        public DateTime bok_lanadagsetning { get; set; }


    }
}