using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Friends.Models
{
    public class Friend
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String ProfilePicture { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public List<Friend> Friends { get; set; }
        public String Country { get; set; }
        public String State { get; set; }

    }
}
