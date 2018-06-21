using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Dojo_League.Models;
 
namespace Dojo_League.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=Dolphins16*;port=3306;database=lost_woods;SslMode=None";
        }

        internal IDbConnection Connection{
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public Dojo FindById(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
                SELECT * FROM dojos WHERE dojo_id = @Id;
                SELECT * FROM ninjas WHERE dojo_id = @Id;
                ";

                using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }

        public void AddDojo(Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO dojos (dojo_name, location, desc, created_at, updated_at)
                    VALUES (@dojo_name, @location, @desc, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, dojo);
            }
        }
    }
}