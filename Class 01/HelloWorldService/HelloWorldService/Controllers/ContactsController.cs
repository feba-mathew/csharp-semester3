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

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable Get()
        {
            return contacts;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        public Contact Get(int id)
        {
            foreach(var contact in contacts)
            {
                if(contact.Id == id)
                {
                    return contact;
                }
            }

            return null;
        }

        // POST: api/Contacts
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            contacts.Add(value);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}