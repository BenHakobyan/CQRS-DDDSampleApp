namespace SampleApp.Application.Commands.Contact
{
    public class DeleteContactCommand : ICommand
    { 
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            this.Id = id;
        }
    }
}
