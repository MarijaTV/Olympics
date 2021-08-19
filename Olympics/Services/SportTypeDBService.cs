using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Olympics.Models;

namespace Olympics.Services
{
    public class SportTypeDBService
    {
        private SqlConnection _connection;

        public SportTypeDBService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<SportTypeModel> AllSports()
        {
            // Reading from db
            _connection.Open();

            List<SportTypeModel> sports = new();

            using var command = new SqlCommand("SELECT * FROM SportsType;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                sports.Add(new SportTypeModel()
                {
                    ID = reader.GetInt32(0),
                    SportsType = reader.GetString(1),
                    SportsName = reader.GetString(2),
                    TeamsActivity = reader.GetBoolean(3)
                });

                // do something with 'value'
            }

            _connection.Close();
            return sports;
        }
        public void AddSport(SportTypeModel sport)
        {
            _connection.Open();
            //// Insert
            //using var command = new SqlCommand("insert into Athlete(lastname, firstname, country) values ('test3', 'test3', 'testemail3')", _connection);
            string insertText = $"insert into" +
                $" dbo.SportsType (SportsType, SportsName, TeamsActivity) " +
                $" values ('{ sport.SportsType}', '{ sport.SportsName}', '{ sport.TeamsActivity}')";
            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }

    }
}
