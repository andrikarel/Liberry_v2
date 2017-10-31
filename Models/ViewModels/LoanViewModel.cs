using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class LoanViewModel
    {
        
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId  { get; set; }
        [Required]
        public DateTime DateOfLoan { get; set; }


    }
}