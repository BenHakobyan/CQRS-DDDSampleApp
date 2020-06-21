using Microsoft.EntityFrameworkCore;
using SampleApp.Domain;
using SampleApp.Domain.Repositories;
using SampleApp.Infrastucture;
using SampleApp.Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.UnitTest
{
    public class TestHelper
    {
        public readonly ContactsContext contactsContext;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<ContactsContext>();
            builder.UseInMemoryDatabase(databaseName: "ContactsDbInMemory");

            var dbContextOptions = builder.Options;
            contactsContext = new ContactsContext(dbContextOptions);
            // Delete existing db before creating a new one
            contactsContext.Database.EnsureDeleted();
            contactsContext.Database.EnsureCreated();
        }

        public IContactRepository GetInMemoryContactRepository()
        {
            return new ContactRepository(contactsContext);
        }

        public IUnitOfWork GetInMemoryUnitOfWork()
        {
            return new UnitOfWork(contactsContext);
        }

    }
}
