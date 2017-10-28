using System;

namespace Liberry_v2.Models.Entites
{
    public class Book
    {
        public int Id { get; set; }
        public String Title  { get; set; }
        public String Author { get; set; }

        public DateTime Published { get; set; }

        public String ISBN { get; set; }


    }
}
