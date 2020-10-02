using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Friend
{
    public class CreateFriend
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public String UrlPicture { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
    }
}
