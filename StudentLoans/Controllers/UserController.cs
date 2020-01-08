using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentLoans.api.Commands;
using StudentLoans.api.Controllers;
using StudentLoans.Models;
using StudentLoans.DataAccess;

namespace StudentLoans.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : FirebaseEnabledController
    {
        // GET api/values
        [HttpPost("createuser")]
        public ActionResult CreateNewUser(AddUserCommand newUserCommand)
        {
           // newUserCommand.FirebaseId = UserId;

            var repo = new UserRepository();
            var userCreated = repo.Add(newUserCommand);

            if (userCreated == null)
            {
                return NotFound("could not create user");
            }

            return Ok();
        }

        [HttpGet("checkuser/{firebaseId}")]
        public int CheckForUserAccount(string firebaseId)
        {
            var repo = new UserRepository();
            var userCheck = repo.CheckForUserAccount(firebaseId);
            return userCheck;
        }
    }
}