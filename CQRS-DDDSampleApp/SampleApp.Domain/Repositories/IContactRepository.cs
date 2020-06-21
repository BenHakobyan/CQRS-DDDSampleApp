using System.Threading.Tasks;

namespace SampleApp.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Entities.Contact> GetByIdAsync(int id);

        Task AddAsync(Entities.Contact customer);

        void Remove(Entities.Contact customer);
    }
}
