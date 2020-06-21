using Microsoft.EntityFrameworkCore;
using SampleApp.Domain;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Repositories;
using System.Threading.Tasks;

namespace SampleApp.Infrastucture.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsContext _context;
        public ContactRepository(ContactsContext context)
        {
            this._context = context;
        }

        public void Add(Contact contact)
        {
           var entry = _context.Attach(contact);
           entry.State = EntityState.Added;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Contact customer)
        {
            _context.Contacts.Remove(customer);
        }

    }
}
