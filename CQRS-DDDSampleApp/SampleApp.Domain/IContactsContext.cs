using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Domain
{
    public interface IContactsContext
    {
        DbSet<Entities.Contact> Contacts { get; set; }
    }
}
