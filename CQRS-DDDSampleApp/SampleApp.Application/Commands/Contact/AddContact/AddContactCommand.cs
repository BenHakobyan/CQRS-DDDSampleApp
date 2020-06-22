namespace SampleApp.Application.Commands.Contact
{
    public class AddContactCommand : ICommand<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public AddContactCommand(
            string fullName,
            string email,
            string phoneNumber,
            string address)
        {
            this.FullName = fullName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
        }
    }
}
