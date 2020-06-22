using MediatR;
using SampleApp.Application.Exceptions;
using SampleApp.Domain;
using SampleApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Application.Commands.Contact
{
    public class EditContactCommandHandler : ICommandHandler<EditContactCommand>
    {
        private readonly IContactsContext _contactsContext;

        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditContactCommandHandler(
            IContactsContext contactsContext,
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {
            this._contactsContext = contactsContext;

            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Contact.Id);

            if (contact == default)
            {
                throw new NotFoundException();
            }

            contact.Edit(request.Contact.FullName, request.Contact.Email, request.Contact.PhoneNumber, request.Contact.Address, _contactsContext);

            await _unitOfWork.CommitAsync(cancellationToken);

            return default;
        }
    }
}
