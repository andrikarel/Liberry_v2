using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class BookViewModel
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public String Title  { get; set; }
        [Required]
        public String AuthorFirstName { get; set; }
        [Required]
        public String AuthorLastName { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public String ISBN { get; set; }
    

    }
}
