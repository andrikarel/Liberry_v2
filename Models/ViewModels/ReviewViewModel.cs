using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        public int BookId  { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime DateWritten { get; set; }
        [Required]
        public int Rating { get; set; }


    }
}