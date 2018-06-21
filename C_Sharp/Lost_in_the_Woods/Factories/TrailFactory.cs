using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Lost_in_the_Woods.Models;
 
namespace Lost_in_the_Woods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_woods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public List<Trail> GetAllTrails(){
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   string query = "SELECT * FROM trails";
                   dbConnection.Open();
                   return dbConnection.Query<Trail>(query).ToList();
                }
            }
        }

        public Trail GetTrail(int id){
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = $"SELECT * FROM trails WHERE trails.id = '{id}'";
                    dbConnection.Open();
                    Trail trail = dbConnection.Query<Trail>(query).FirstOrDefault();
                    return trail;
                }
            }
        }

        public void AddTrail(Trail trail){
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO trails (trail_name, description, trail_length, elev_change, longitude, latitude, created_at, updated_at) 
                    VALUES (@trail_name, @description, @trail_length, @elev_change, @longitude, @latitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
    }
}