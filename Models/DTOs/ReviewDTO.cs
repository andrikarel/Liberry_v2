using System;

namespace Liberry_v2.Models.Entites
{
    public class ReviewDTO
    {
        public int ID { get; set; }
        public int BookId  { get; set; }
        public int UserId { get; set; }
        public DateTime DateWritten { get; set; }
        public int Rating { get; set; }


    }
}