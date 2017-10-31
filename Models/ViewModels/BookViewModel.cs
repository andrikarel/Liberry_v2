using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public String Title  { get; set; }
        [Required]
        public String Author { get; set; }
        [Required]
        public DateTime Published { get; set; }
        [Required]
        public String ISBN { get; set; }
    

    }
}
