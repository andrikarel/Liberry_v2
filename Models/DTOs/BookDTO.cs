using System;

namespace Liberry_v2.Models.DTOs
{
    public class BookDTO
    {
      
        public int Id { get; set; }
       
        public String Title  { get; set; }
        
        public String Author { get; set; }
        public DateTime Published { get; set; }
        
        public String ISBN { get; set; }

    }
}
