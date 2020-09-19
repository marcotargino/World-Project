using System;

namespace WebApp.Models.Friend
{
    public class ListFriend
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Country { get; set; }
        public String State { get; set; }

    }
}
