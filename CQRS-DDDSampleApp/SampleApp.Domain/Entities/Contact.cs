using SampleApp.Domain.Rules.Contact;

namespace SampleApp.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }

        private Contact()
        {

        }

        public static Contact Create(string fullName, string email, string phoneNumber, string address, IContactsContext contactsContext)
        {
            var contact = new Contact()
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            CheckRule(new ContactMustBeUniqueRule(contactsContext, contact));

            return contact;
        }

        public void Edit(string fullName, string email, string phoneNumber, string address, IContactsContext contactsContext)
        {
            this.FullName = fullName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;

            CheckRule(new ContactMustBeUniqueRule(contactsContext, this));
        }
    }
}
