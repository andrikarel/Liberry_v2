using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Liberry_v2.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String FirstName  { get; set; }
        [Required]
        public String LastName  { get; set; }
      
        public String Address {get; set; }
        [Required]
        public String Email { get; set; }
        
        public List<LoanViewModel> lanasafn {get; set;}
      

    }
}