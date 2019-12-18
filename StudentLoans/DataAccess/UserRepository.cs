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
    }
}
