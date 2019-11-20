using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLoans.Models;
using System.Data.SqlClient;
using Dapper;

namespace StudentLoans.DataAccess
{
    public class ProductRepository
    {
        string _connectionString = "Server=localhost;Database=StudentLoans;Trusted_Connection=True;";

        public IEnumerable<Product> GetAllProducts()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = "Select * from Products;";
                var products = db.Query<Product>(sql);
                return products;
            }
        }

    }
}
