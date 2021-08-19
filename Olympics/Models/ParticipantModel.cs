using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class ParticipantModel
    {
        public List<AthleteModel> Athlete { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<SportTypeModel> Sports { get; set; }
        public SortFilterModel SortFilter { get; set; }

        public int[] sportIds { get; set; }

    }


}
