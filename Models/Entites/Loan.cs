using System;

namespace Liberry_v2.Models.Entites
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId  { get; set; }


        public DateTime DateOfLoan { get; set; }


    }
}