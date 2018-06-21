using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Dojo_League.Models;
 
namespace Dojo_League.Factory
{
    public class NinjaFactory : IFactory<Dojo>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_woods;SslMode=None";
        }

        internal IDbConnection Connection{
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public IEnumerable<Ninja> NinjasForDojoById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id WHERE dojos.dojo_id = ninjas.dojo_id AND dojos.dojo_id = {id}";
                dbConnection.Open();

                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => {ninja.dojo = dojo; return ninja;});
                return myNinjas;
            }
        }

        public void AddNinja(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO ninjas (name, level, description, created_at, updated_at, dojo_id)
                    VALUES (@name, @level, @description, NOW(), NOW(), @dojo_id)";
                dbConnection.Open();
                dbConnection.Execute(query, ninja);
            }
        }

        public void RecruitNinja(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = null WHERE ninja_id = @Id";
            }
        }
    }
}
