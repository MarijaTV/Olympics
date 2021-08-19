using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using Olympics.Models;

namespace Olympics.Services
{
    public class ParticipantDBService
    {
        private AthleteDBService _athleteDBService;
        private CountryDBService _countryDBService;
        private SportTypeDBService _sportTypeDBService;
        private SqlConnection _connection;

        public ParticipantDBService(AthleteDBService athleteDBService, CountryDBService countryDBService, SportTypeDBService sportTypeDBService, SqlConnection connection)
        {
            _athleteDBService = athleteDBService;
            _countryDBService = countryDBService;
            _sportTypeDBService = sportTypeDBService;
            _connection = connection;
        }

        public ParticipantModel All()
        {
            ParticipantModel Participants = new()
            {
                Athlete = _athleteDBService.AllAlthletes(),
                Countries = _countryDBService.AllCountries(),
                Sports = _sportTypeDBService.AllSports(),
            };
            return Participants;

        }
        public ParticipantModel AddParticipant()
        {
            List<AthleteModel> Athletes = new();
            Athletes.Add(new AthleteModel());

            ParticipantModel Participants = new()
            {
                Athlete = Athletes,
                Countries = _countryDBService.AllCountries(),
                Sports = _sportTypeDBService.AllSports(),

            };
            return Participants;
        }

        

        public void SaveAthlete(ParticipantModel participants)
        {
            _athleteDBService.AddParticipant(participants);
        }
    }
}
