using SampleApp.Application.DTO;

namespace SampleApp.Application.Queries.Contact
{
    public class GetContactByIdQuery : IQuery<ContactDTO>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
