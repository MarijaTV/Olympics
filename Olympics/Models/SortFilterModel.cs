using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class SortFilterModel
    {
        public string sortBy { get; set; }
        public string orderBy { get; set; }
        public int filterByCountryId { get; set; }
        public string filterBySport { get; set; }
        public bool filteByTeamActivity { get; set; }
    }
}
