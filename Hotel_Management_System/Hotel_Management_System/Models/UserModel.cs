using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.Models
{
    internal class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string LastName { get; internal set; }
        public string Email { get; set; }

        public static implicit operator UserModel(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
