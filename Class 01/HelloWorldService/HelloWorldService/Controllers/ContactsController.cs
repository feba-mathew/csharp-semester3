using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelloWorldService.Models;
using System.Collections;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public static List<Contact> contacts = new List<Contact>();
        public static int currentId = 101;

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }
        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return new OkObjectResult(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            value.Id = currentId++;
            value.DateAdded = DateTime.Now;

            contacts.Add(value);

            //var result = new { Id = value.Id, Candy = true };

            return CreatedAtAction(nameof(Get),
                new { id = value.Id },
                value);
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact value)
        {
            var contact = contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.Id = id;
            contact.Name = value.Name;
            contact.Phones = value.Phones;

            return Ok(contact);
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactsRemoved = contacts.RemoveAll(t => t.Id == id);

            if (contactsRemoved == 0)
            {
                return NotFound(); //404
            }

            return Ok(); //200
        }
    }
}