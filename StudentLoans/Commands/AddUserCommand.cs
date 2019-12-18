using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentLoans.api.Commands
{
    public class AddUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirebaseId { get; set; }
    }
}
