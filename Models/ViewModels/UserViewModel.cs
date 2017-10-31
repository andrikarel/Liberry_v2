using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public String Name  { get; set; }
        public String Address {get; set; }
        [Required]
        public String UserType {get; set; }
        [Required]
        public String Email { get; set; }
    }
}