using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Places.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public String CountryName { get; set; }
        public String CountryFlag { get; set; }
        public List<State> States { get; set; }
    }
}