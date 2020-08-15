using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloWorldService.Models;
using System.Security.Cryptography;
using System.Text;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User>();
        public static int currentId = 0;

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            // Return all the users
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Get a user with a specific id
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return new OkObjectResult(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            // Add a new user
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.UserId = ++currentId;
            value.CreatedDate = DateTime.Now;
            value.UserPassword = GetHash(SHA256.Create(), value.UserPassword);

            users.Add(value);

            return CreatedAtAction(nameof(Get), new { id = value.UserId }, value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            // Update an existing user
            var user = users.FirstOrDefault(t => t.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserEmail = value.UserEmail;
            user.UserPassword = GetHash(SHA256.Create(), value.UserPassword);

            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete an existing user(s)
            var usersRemoved = users.RemoveAll(t => t.UserId == id);

            if (usersRemoved == 0)
            {
                return NotFound();
            }

            return Ok(usersRemoved);
        }

        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}