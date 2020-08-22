using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Interfaces;
using myblog.Models;

namespace myblog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository repos;

        public ContactsController(IContactRepository _contactsRepos)
        {
            repos = _contactsRepos;
        }

        [HttpGet]
        public async Task<IEnumerable<Contacts>> Get()
        {
            return await repos.GetAsync();
        }

        [HttpGet("{id}")] //api/Contacts/:id
        public async Task<ActionResult<Contacts>> Get(Guid id)
        {
            return await repos.GetAsync(id) ?? NotFound();
        }

        [HttpPost("/api/Contacts/Update")]
        public async Task<ActionResult<Contacts>> Update(Contacts obj)
        {
            return await repos.Update(obj);
        }

        [HttpPost("/api/Contacts/Create")]
        public async Task Create(Contacts obj)
        {
            await repos.Create(obj);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await repos.Delete(id);
        }


        /*ШПАРГАЛКА!*/
        // GET: api/Contacts
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacts>> GetContacts(Guid id)
        {
            var contacts = await _context.Contacts.FindAsync(id);

            if (contacts == null)
            {
                return NotFound();
            }

            return contacts;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacts(Guid id, Contacts contacts)
        {
            if (id != contacts.Id)
            {
                return BadRequest();
            }

            _context.Entry(contacts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contacts>> PostContacts(Contacts contacts)
        {
            _context.Contacts.Add(contacts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = contacts.Id }, contacts);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contacts>> DeleteContacts(Guid id)
        {
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contacts);
            await _context.SaveChangesAsync();

            return contacts;
        }

        private bool ContactsExists(Guid id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }*/
    }
}
