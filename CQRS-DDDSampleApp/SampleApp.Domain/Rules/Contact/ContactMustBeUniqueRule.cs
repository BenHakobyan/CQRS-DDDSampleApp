using System.Linq;

namespace SampleApp.Domain.Rules.Contact
{
    public class ContactMustBeUniqueRule : IBusinessRule
    {
        private readonly IContactsContext _contactsContext;

        private readonly Entities.Contact _contact;

        private string _paramName;

        public ContactMustBeUniqueRule(
            IContactsContext contactsContext,
            Entities.Contact contact)
        {
            _contactsContext = contactsContext;
            _contact = contact;
        }

        public bool IsBroken() 
        {
            //can be optimized by Union
            if(_contactsContext.Contacts.Where(c => c.FullName == _contact.FullName && c.Id != _contact.Id).Any())
            {
                _paramName = "Full Name";
                return true;
            }
            else if (_contactsContext.Contacts.Where(c => c.Email == _contact.Email && c.Id != _contact.Id).Any())
            {
                _paramName = "Email";
                return true;
            }
            else if (_contactsContext.Contacts.Where(c => c.PhoneNumber == _contact.PhoneNumber && c.Id != _contact.Id).Any())
            {
                _paramName = "Phone Number";
                return true;
            }

            return false;
        }

        public string Message => string.Format("Contact with this {0} already exists.", _paramName);
    }
}
