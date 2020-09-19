using System;

namespace WebApi_Places.Models
{
    public class State
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public String SatateName { get; set; }
        public String StateFlag { get; set; }
    }
}
