using System;

namespace Liberry_v2.Models.DTOs
{
    public class LoanDTO
    {
  
        public int UserId { get; set; }
        public int BookId  { get; set; }
        public DateTime DateOfLoan { get; set; }
        public bool IsReturned { get; set; }


    }
}