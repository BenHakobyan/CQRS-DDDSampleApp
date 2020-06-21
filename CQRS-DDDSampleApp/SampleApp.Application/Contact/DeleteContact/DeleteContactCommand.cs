using SampleApp.Application.Commands;

namespace SampleApp.Application.Contact.DeleteContact
{
    public class DeleteContactCommand : ICommand
    { 
        public int Id { get; set; }
    }
}
