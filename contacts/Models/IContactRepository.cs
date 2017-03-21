using System.Collections.Generic;

namespace ContactApi.Models
{
    public interface IContactRepository
    {
        void Add(ContactForm item);
        IEnumerable<ContactForm> GetAll();
        ContactForm Find(long key);
        void Remove(long key);
        void Update(ContactForm item);
    }
}
