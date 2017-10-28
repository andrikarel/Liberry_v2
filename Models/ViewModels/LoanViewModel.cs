using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class LoanViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BookId  { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }


    }
}