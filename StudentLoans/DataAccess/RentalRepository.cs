using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentLoans.Models;
using System.Data.SqlClient;
using Dapper;

namespace StudentLoans.DataAccess
{
    public class RentalRepository
    {
        string _connectionString = "Server=localhost;Database=StudentLoans;Trusted_Connection=True;";

        public IEnumerable<Rental> GetRentalsByProductOwner(string ownerFirebaseId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"
                        SELECT 
                            r.Id,
						    r.ProductId,
						    r.RenterId,
						    r.TotalCost,
                            c.Type as PaymentType,
						    r.StartDate,
						    r.ReturnedDate,
						    p.[Name] as ProductName,
                            p.ImageUrl,
						    p.PricePerDay,
						    CONCAT(u.FirstName, ' ', u.LastName) as OwnerFullName
                        FROM Rentals r
                        LEFT JOIN Products p on p.Id = r.ProductId
                        LEFT JOIN Users u on u.Id = p.OwnerId
                        LEFT JOIN CustomerPaymentTypes c on c.Id = r.PaymentTypeId
                        WHERE u.FireBaseId = @FirebaseId";
                var param = new { FirebaseId = ownerFirebaseId };
                var OwnerRentals = db.Query<Rental>(sql, param);
                return OwnerRentals;
            }
        }
    }
}
