using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Olympics.Models
{
    public class AthleteModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public string Sports { get; set; }
        public List<SportTypeModel> SportsType { get; set; }
        public List<CountryModel> Countries { get; set; }
    }
}
