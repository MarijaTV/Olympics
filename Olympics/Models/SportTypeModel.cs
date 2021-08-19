using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Models
{
    public class SportTypeModel
    {
        public int ID { get; set; }
        public string SportsType { get; set; }
        public string SportsName { get; set; }
        public bool TeamsActivity { get; set; }
    }
}
