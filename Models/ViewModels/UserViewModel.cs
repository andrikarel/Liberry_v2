using System;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public String Name  { get; set; }
        [Required]
        public String Address {get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String ISBN { get; set; }

    }
}