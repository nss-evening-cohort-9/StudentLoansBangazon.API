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

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                //newCategory adds % to both sides of the search term to make it soft search
                var newCategory = "%" + category + "%";
                var sql = @"SELECT
                                p.*
                            FROM Products p
                                JOIN ProductTypes pt on pt.Id = p.productTypeId
                            WHERE pt.name LIKE @categoryName";
                var param = new { categoryName = newCategory };
                var products = db.Query<Product>(sql, param);
                return products;
            }
        }

        public IEnumerable<Product> GetHomePageProducts()
        {

            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT TOP (20) 
                              Id,
                              [Name],
                              ProductTypeId,
                              PricePerDay,
                              Description,
                              OwnerId,
                              IsRented,
                              ImageUrl
                              FROM 
                                  Products
                             ORDER BY 
			                		ListDate DESC;"; 
                var products = db.Query<Product>(sql);
                return products;
            }
        }

        public IEnumerable<Product> GetProductsByName(string searchTerm)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                //newSearchTerm adds % to both sides of the search term to make it soft search
                var newSearchTerm = "%" + searchTerm + "%";
                var sql = @"SELECT
                                p.*
                            FROM Products p
                            WHERE p.name LIKE @Name";
                var param = new { Name = newSearchTerm };
                var products = db.Query<Product>(sql, param);
                return products;
            }
        }

    }
}
