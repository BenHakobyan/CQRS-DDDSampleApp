using SampleApp.Application.DTO;
using System.Collections.Generic;

namespace SampleApp.Application.Queries.Contact
{
    public class GetContactListQuery : IQuery<List<ContactDTO>>
    {
        public GetContactListQuery() { }
    }
}
