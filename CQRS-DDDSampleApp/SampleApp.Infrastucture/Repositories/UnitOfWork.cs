using SampleApp.Domain;
using SampleApp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactsContext _context;
        public UnitOfWork(ContactsContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}
