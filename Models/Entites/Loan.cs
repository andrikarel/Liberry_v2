using System;

namespace Liberry_v2.Models.Entites
{
    public class Loan
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId  { get; set; }


        public DateTime LoanDate { get; set; }


    }
}