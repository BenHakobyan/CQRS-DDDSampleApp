using SampleApp.Application.DTO;

namespace SampleApp.Application.Commands.Contact
{
    public class EditContactCommand : ICommand
    {
        public ContactDTO Contact { get; set; }

        public EditContactCommand(ContactDTO contact)
        {
            this.Contact = contact;
        }
    }
}
