using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLoans.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RenterId { get; set; }
        public string RenterFullName { get; set; }
        public string PaymentType { get; set; }
        public string StartDate { get; set; }
        public string ReturnedDate { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal TotalRentalIncome { get; set; }
        public string OwnerFullName { get; set; }
    }
}
