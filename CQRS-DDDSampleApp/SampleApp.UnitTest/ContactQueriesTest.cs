using FluentAssertions;
using SampleApp.Application.Queries.Contact;
using SampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SampleApp.UnitTest
{
    [Collection("Sequential")]
    public class ContactQueriesTest
    {
        [Fact]
        public async void GetContactByIdQueryTest()
        {
            //Arange
            var testHelper = new TestHelper();

            var contact = Contact.Create("someone", "someone@example.com", "156464654", null, testHelper.contactsContext);

            await testHelper.contactsContext.AddAsync(contact);
            await testHelper.contactsContext.SaveChangesAsync();

            GetContactByIdQuery query = new GetContactByIdQuery(contact.Id);
            GetContactByIdQueryHandler handler = new GetContactByIdQueryHandler(testHelper.contactsContext);

            //Act
            var result = await handler.Handle(query, default);

            //Asert
            result.Should().NotBeNull();
            result.FullName.Should().Be("someone");
        }

        [Fact]
        public async void GetContactListQueryTest()
        {
            //Arange
            var testHelper = new TestHelper();

            var contactCount = 5;

            for (int i = 0; i < contactCount; i++)
            {
                var contact = Contact.Create($"someone{i}", $"someone{i}@example.com", $"156464654{i}", null, testHelper.contactsContext);

                await testHelper.contactsContext.AddAsync(contact);
                await testHelper.contactsContext.SaveChangesAsync();
            }

            GetContactListQuery query = new GetContactListQuery();
            GetContactListQueryHandler handler = new GetContactListQueryHandler(testHelper.contactsContext);

            //Act
            var result = await handler.Handle(query, default);

            //Asert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(2);
        }
    }
}
