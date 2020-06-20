using SampleApp.Domain.Contact.Checkers;

namespace SampleApp.Domain.Rules.Contact
{
    public class ContactMustBeUniqueRule : IBusinessRule
    {
        private readonly IContactUniquenessChecker _contactUniquenessChecker;

        private readonly Entities.Contact _contact;

        private string _paramName;

        public ContactMustBeUniqueRule(
            IContactUniquenessChecker contactUniquenessChecker,
            Entities.Contact contact)
        {
            _contactUniquenessChecker = contactUniquenessChecker;
            _contact = contact;
        }

        public bool IsBroken() => _contactUniquenessChecker.Check(_contact, out _paramName);

        public string Message => string.Format("Contact with this {0} already exists.", _paramName);
    }
}
