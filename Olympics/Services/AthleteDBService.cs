using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Olympics.Models;

namespace Olympics.Services
{
    public class AthleteDBService
    {
        private SqlConnection _connection;

        public AthleteDBService(SqlConnection connection)
        {
            _connection = connection;
        }


        public List<AthleteModel> AllAlthletes()
        {
            List<AthleteModel> athletes = new();

            // Reading from db
            _connection.Open();


            //using var command = new SqlCommand("SELECT * FROM Athlete;", _connection);
            using var command = new SqlCommand($@"SELECT a.ID, a.LastName, a.FirstName, a.CountryId, c.CountryName, STRING_AGG(s.SportsType, ', ') AS 'sports'
                                                FROM Athlete a
                                                JOIN Countries c
                                                ON a.countryID = c.ID
                                                Left JOIN AthleteSports ats
                                                ON a.id = ats.AthleteId
                                                Left JOIN SportsType s
                                                ON ats.SportsTypeID = s.ID
                                                GROUP BY a.id, a.LastName, a.FirstName, a.countryID, c.CountryName", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athletes.Add(new()
                {
                    Id = reader.GetInt32(0),
                    LastName = reader.GetString(1),
                    FirstName = reader.GetString(2),
                    CountryId = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                    CountryName = reader.GetString(4),
                    Sports = reader.IsDBNull(5) ? null : reader.GetString(5)
                });

                // do something with 'value'
            }

            _connection.Close();
            return athletes;
        }


        public void AddParticipant(ParticipantModel participant)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand($" insert into Athlete (LastName, FirstName, CountryId) " +
                $" values ('{participant.Athlete[0].LastName}', '{participant.Athlete[0].FirstName}', {participant.Athlete[0].CountryId})", _connection);
            command.ExecuteNonQuery();
            _connection.Close();

            //reikia nuskaityti iš dbo.Athelete išsaugotą įrašą???

            int athleteId = GetAthleteId(participant);

            _connection.Open();
            foreach (var sports in participant.sportIds)
            {
                SqlCommand command2 = new SqlCommand($" insert into AthleteSports (AthleteID, SportsTypeID) " +
                    $" values ({athleteId}, {sports})", _connection);
                command2.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public int GetAthleteId(ParticipantModel participant)
        {
            _connection.Open();
            SqlCommand command = new($@"SELECT MAX(id) FROM Athlete
                                                WHERE LastName = '{participant.Athlete[0].LastName}' 
                                                AND FirstName = '{participant.Athlete[0].FirstName}'", _connection);
            int athleteId = (Int32)command.ExecuteScalar();
            _connection.Close();
            return athleteId;
        }

        

        //public void Edit(ParticipantModel participant)
        //{
        //    _connection.Open();
        //    var command = new SqlCommand($"UPDATE Athlete SET [LastName] = '{participant.Athlete.LastName}' ,[LastName] = '{participant.Athlete.LastName}' ,[Country] = {participant.Athlete.Country} WHERE[dbo].[Athlete].[ID] = {participant.Athlete.ID}", _connection);
        //    var reader = command.ExecuteReader();
        //    _connection.Close();

        //    _connection.Open();
        //    var command2 = new SqlCommand($"DELETE FROM [dbo].[Athlete_Sports] WHERE [Athlete_id] = {participant.Athlete.Id}", _connection);
        //    var reader2 = command2.ExecuteReader();
        //    _connection.Close();

        //    foreach (var sport in participant.Athlete)
        //    {
        //        _connection.Open();
        //        var command3 = new SqlCommand($"INSERT INTO [dbo].[Athlete_Sports] ([Athlete_id], [Sports_id]) VALUES ({participant.Athlete.Id}, {sport})", _connection);
        //        var reader3 = command3.ExecuteReader();
        //        _connection.Close();
        //    }

        //}
    }
}



