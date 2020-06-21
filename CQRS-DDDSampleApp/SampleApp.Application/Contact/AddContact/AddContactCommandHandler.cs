using SampleApp.Application.Commands;
using SampleApp.Domain;
using SampleApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Application.Contact.AddContact
{
    public class AddContactCommandHandler : ICommandHandler<AddContactCommand, int>
    {
        private readonly IContactsContext _contactsContext;

        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddContactCommandHandler(
            IContactsContext contactsContext,
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {
            this._contactsContext = contactsContext;
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var contact = Domain.Entities.Contact.Create(request.FullName, request.Email, request.Address, request.PhoneNumber, _contactsContext);

            await _contactRepository.AddAsync(contact);

            await _unitOfWork.CommitAsync(cancellationToken);

            return contact.Id;
        }
    }
}
