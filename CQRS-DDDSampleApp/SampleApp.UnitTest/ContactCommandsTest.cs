using FluentAssertions;
using SampleApp.Application.Commands.Contact;
using SampleApp.Domain.Entities;
//using SampleApp.Application.Commands.Contact;
using Xunit;

namespace SampleApp.UnitTest
{
    [Collection("Sequential")]
    public class ContactCommandsTest
    {
        [Fact]
        public async void AddContactCommandTest()
        {
            //Arange
            var testHelper = new TestHelper();

            AddContactCommand command = new AddContactCommand("someone", "someone@example.com", "156464654", null);
            AddContactCommandHandler handler = new AddContactCommandHandler(testHelper.contactsContext, testHelper.GetInMemoryContactRepository(), testHelper.GetInMemoryUnitOfWork());

            //Act
            var insertedId = await handler.Handle(command, new System.Threading.CancellationToken());
            var contact = await testHelper.GetInMemoryContactRepository().GetByIdAsync(insertedId);

            //Asert
            insertedId.Should().BeGreaterThan(0);
            contact.Should().NotBeNull();
        }


        [Fact]
        public async void EditContactCommandTest()
        {
            //Arange
            var testHelper = new TestHelper();

            var contact = Contact.Create("someone", "someone@example.com", "156464654", null, testHelper.contactsContext);

            await testHelper.contactsContext.AddAsync(contact);
            await testHelper.contactsContext.SaveChangesAsync();

            EditContactCommand editCommand = new EditContactCommand(new Application.DTO.ContactDTO() { Id = contact.Id, FullName = "another", Email = "another@test.com", PhoneNumber = "123456", Address = "herguhrgrhg" });
            EditContactCommandHandler editContactCommandHandler = new EditContactCommandHandler(testHelper.contactsContext, testHelper.GetInMemoryContactRepository(), testHelper.GetInMemoryUnitOfWork());

            //Act
            await editContactCommandHandler.Handle(editCommand, default);
            var updatedContact = await testHelper.GetInMemoryContactRepository().GetByIdAsync(contact.Id);

            //Assert
            updatedContact.Should().NotBeNull();
            updatedContact.FullName.Should().Be("another");
        }

        [Fact]
        public async void DeleteContactCommandTest()
        {
            //Arange
            var testHelper = new TestHelper();

            var contact = Contact.Create("someone", "someone@example.com", "156464654", null, testHelper.contactsContext);

            await testHelper.contactsContext.AddAsync(contact);
            await testHelper.contactsContext.SaveChangesAsync();

            DeleteContactCommand deleteCommand = new DeleteContactCommand(contact.Id);
            DeleteContactCommandHandler deleteContactCommandHandler = new DeleteContactCommandHandler(testHelper.GetInMemoryContactRepository(), testHelper.GetInMemoryUnitOfWork());

            //Act
            await deleteContactCommandHandler.Handle(deleteCommand, default);
            var deletedContact = await testHelper.GetInMemoryContactRepository().GetByIdAsync(contact.Id);

            //Assert
            deletedContact.Should().BeNull();
        }
    }
}
