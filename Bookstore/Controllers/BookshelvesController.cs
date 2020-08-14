using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("/books/v1/users/{userId:alpha}/[controller]")]
    public class BookshelvesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string userId)
        {
            if (string.IsNullOrEmpty(userId))// Mock user validation failed.
            {
                Error error = new Error() { Code = "400", Message = "Invalid user name or user does not exists." };
                return BadRequest(new List<Error>() { error });
            }

            List<Bookshelves> bookshelves = new List<Bookshelves>();
            bookshelves.Add(new Bookshelves()
            {
                Id = 1,
                Name = "Have to Read"
            });

            bookshelves.Add(new Bookshelves()
            {
                Id = 2,
                Name = "Favourite books"
            });

            return Ok(bookshelves);
        }
    }
}
