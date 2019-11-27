using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLoans.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public float PricePerDay { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool IsRented { get; set; }
        public DateTime ListDate { get; set; }
        public string ImageUrl { get; set; }


    }
}
