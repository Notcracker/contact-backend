using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactApi.Models;
using Microsoft.AspNetCore.Cors;

namespace ContactApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository ContactRepository)
        {
            _contactRepository = ContactRepository;
        }

        [HttpGet]
        public IEnumerable<ContactForm> GetAll()
        {
            return _contactRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(long id)
        {
            var item = _contactRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContactForm item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _contactRepository.Add(item);

            return CreatedAtRoute("GetContact", new { id = item.Key }, item);
        }

    }
}
