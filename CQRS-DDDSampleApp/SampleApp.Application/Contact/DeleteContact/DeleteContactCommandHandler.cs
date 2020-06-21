using MediatR;
using SampleApp.Application.Commands;
using SampleApp.Application.Exceptions;
using SampleApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Application.Contact.DeleteContact
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(
            IContactRepository contactRepository,
            IUnitOfWork unitOfWork)
        {

            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == default)
            {
                throw new NotFoundException();
            }

            _contactRepository.Remove(contact);

            await _unitOfWork.CommitAsync();

            return default;
        }
    }
}
