using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using StudentLoans.api.Commands;

namespace StudentLoans.DataAccess
{
    public class UserRepository
    {
        string _connectionString = "Server=localhost;Database=StudentLoans;Trusted_Connection=True;";

        public int Add(AddUserCommand NewUser)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Users
                            VALUES (
                              @FirstName,
                              @LastName,
                              getdate(),
                              @FireBaseId
                            );";
                return db.Execute(sql, NewUser);
            }
        }

        public int CheckForUserAccount(string firebaseId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT
                                count(1)
                            FROM Users u
                            WHERE u.firebaseId = @FirebaseId;";
                var param = new { FirebaseId = firebaseId };
                var output = db.QueryFirst<int>(sql, param);
                return output;
            }
        }
    }
}
