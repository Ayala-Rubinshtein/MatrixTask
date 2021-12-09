using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        public int IDUser { get; set; }
        public int Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
