using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User
            {
                ID=1,
                FirstName="Goran",
                LastName="Kuzmanoski",
                Age=29
            },
            new User
            {
                ID=2,
                FirstName="Jovan",
                LastName="Jovanoski",
                Age=21
            },
                new User
            {
                ID=3,
                FirstName="Vladimir",
                LastName="Poposlki",
                Age=9
            }
        };
        // GET api/users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, _users);
        }
        [HttpGet("{id}")]

        public ActionResult<User> Get(int id)
        {
            User user = _users.FirstOrDefault(x => x.ID == id);
            
            if(null==user)
            {
                return NotFound(new { message = $"User with {id} not found.", suggestion = 1 });
            }   
            return user;
        }

        [HttpGet("{id}/is_adult")]
        public ActionResult<string> IsAdult(int id)
        {
            User user = _users.FirstOrDefault(x => x.ID == id);

            if (null == user)
            {
                return NotFound(new { message = $"User with {id} not found.", suggestion = 1 });
            }
            else if(user.Age>18)
            {
                return Ok("The user is adult");
            }
            return Ok("The user is teenager");
        }


    }
}