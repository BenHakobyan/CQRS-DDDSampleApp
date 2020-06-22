using Microsoft.EntityFrameworkCore;
using SampleApp.Application.DTO;
using SampleApp.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Application.Queries.Contact
{
    public class GetContactByIdQueryHandler : IQueryHandler<GetContactByIdQuery, ContactDTO>
    {
        private readonly IContactsContext _contactsContext;
        public GetContactByIdQueryHandler(IContactsContext contactsContext)
        {
            this._contactsContext = contactsContext;
        }

        public async Task<ContactDTO> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            return await _contactsContext.Contacts
                                .Where(c => c.Id == request.Id)
                                .Select(c => new ContactDTO
                                {
                                    Id = c.Id,
                                    FullName = c.FullName,
                                    Email = c.Email,
                                    Address = c.Address,
                                    PhoneNumber = c.PhoneNumber
                                }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
