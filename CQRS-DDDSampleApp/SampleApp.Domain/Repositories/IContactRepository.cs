using SampleApp.Domain.Entities;
using System.Threading.Tasks;

namespace SampleApp.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetByIdAsync(int id);

        Task AddAsync(Contact customer);
    }
}
