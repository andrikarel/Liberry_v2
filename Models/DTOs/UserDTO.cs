using System;

namespace Liberry_v2.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public String Name  { get; set; }
        public String Address {get; set; }
        public String UserType {get; set; }

        public String Email { get; set; }


    }
}