using SampleApp.Domain.ModelValidators;
using System.Linq;

namespace SampleApp.Domain.Rules.Contact
{
    public class ContactModelValidationRule : IModelStateRule
    {
        private readonly Entities.Contact _contact;

        private string _message = string.Empty;

        public ContactModelValidationRule(Entities.Contact contact)
        {
            this._contact = contact;
        }

        public string Message => _message;

        public bool IsBroken()
        {
            var validator = new ContactValidator();

            var result = validator.Validate(_contact);

            if (!result.IsValid)
            {
                _message = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                return true;
            }

            return false;
        }
    }
}
