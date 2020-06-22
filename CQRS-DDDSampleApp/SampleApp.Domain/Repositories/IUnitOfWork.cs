using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
