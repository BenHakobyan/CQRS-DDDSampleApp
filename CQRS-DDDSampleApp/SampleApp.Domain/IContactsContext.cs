using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Domain
{
    public interface IContactsContext
    {
        DbSet<Entities.Contact> Contacts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
