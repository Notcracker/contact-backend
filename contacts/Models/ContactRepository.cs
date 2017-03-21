using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactApi.Models
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactForm> GetAll()
        {
            return _context.ContactForms.ToList();
        }

        public void Add(ContactForm item)
        {
            _context.ContactForms.Add(item);
            _context.SaveChanges();
        }

        public ContactForm Find(long key)
        {
            return _context.ContactForms.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.ContactForms.First(t => t.Key == key);
            _context.ContactForms.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ContactForm item)
        {
            _context.ContactForms.Update(item);
            _context.SaveChanges();
        }
    }
}
