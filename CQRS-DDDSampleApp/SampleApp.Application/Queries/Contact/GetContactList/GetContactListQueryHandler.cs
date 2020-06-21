using Microsoft.EntityFrameworkCore;
using SampleApp.Application.DTO;
using SampleApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Application.Queries.Contact
{
    class GetContactListQueryHandler : IQueryHandler<GetContactListQuery, List<ContactDTO>>
    {
        private readonly IContactsContext _contactsContext;
        public GetContactListQueryHandler(IContactsContext contactsContext)
        {
            this._contactsContext = contactsContext;
        }

        public async Task<List<ContactDTO>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            return await _contactsContext.Contacts
                                .Select(c => new ContactDTO
                                {
                                    Id = c.Id,
                                    FullName = c.FullName,
                                    Email = c.Email,
                                    Address = c.Address,
                                    PhoneNumber = c.PhoneNumber
                                }).ToListAsync(cancellationToken);
        }
    }
}
