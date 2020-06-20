using SampleApp.Domain.Contact.Checkers;
using SampleApp.Domain.Rules.Contact;

namespace SampleApp.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        private Contact()
        {

        }

        public static Contact Create(string fullName, string email, string phoneNumber, string address, IContactUniquenessChecker contactUniquenessChecker)
        {
            var contact = new Contact()
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            CheckRule(new ContactMustBeUniqueRule(contactUniquenessChecker, contact));

            return contact;
        }
    }
}
