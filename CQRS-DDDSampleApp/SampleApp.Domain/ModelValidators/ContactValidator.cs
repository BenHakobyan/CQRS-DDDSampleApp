using FluentValidation;
using SampleApp.Domain.Entities;

namespace SampleApp.Domain.ModelValidators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            // FullName
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName cannot be empty");
            RuleFor(x => x.FullName).MaximumLength(255).WithMessage("FullName cannot be more than 255 characters");

            // Email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.Email).MaximumLength(255).WithMessage("Email cannot be more than 255 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect email format");

            // PhoneNumber
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be empty");
            RuleFor(x => x.PhoneNumber).MaximumLength(255).WithMessage("PhoneNumber cannot be more than 255 characters");

            // Address
            RuleFor(x => x.Address).MaximumLength(255).WithMessage("Address cannot be more than 255 characters");
        }
    }
}
