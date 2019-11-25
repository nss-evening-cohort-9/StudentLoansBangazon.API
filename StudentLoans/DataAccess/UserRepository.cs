using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLoans.Models;
using System.Data.SqlClient;
using Dapper;

public class UserRepository
{
	public Class1()
	{
	}
}


namespace StudentLoans.DataAccess
{
    public class UserAuthentication
    {
        string _connectionString = "Server=localhost;Database=StudentLoans;Trusted_Connection=True;";

        public IEnumerable<User> GetAllUserss()
        {
            //using (var db = new SqlConnection(_connectionString))
            {
                var sql = "Select count(*) from Users where Id = @firebaseId;";
                var users  = db.Query<Users>(sql);
                return users;
            }
        }

    }
}
