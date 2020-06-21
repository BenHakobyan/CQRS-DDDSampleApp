using Microsoft.EntityFrameworkCore;
using SampleApp.Domain;
using SampleApp.Domain.Entities;

namespace SampleApp.Infrastucture
{
    public class ContactsContext : DbContext, IContactsContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsContext).Assembly);
        }
    }
}
