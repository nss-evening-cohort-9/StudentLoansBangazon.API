using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentLoans.api.Controllers;
using StudentLoans.Models;
using StudentLoans.DataAccess;

namespace StudentLoans.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalController : FirebaseEnabledController
    {
        // GET api/values
        [HttpGet("owner/{firebaseId}")]
        public IEnumerable<Rental> GetRentalsByProductOwner(string firebaseId)
        {
            var repo = new RentalRepository();
            var ownerRentals = repo.GetRentalsByProductOwner(firebaseId);
            return ownerRentals;
        }
    }
}
