using NLayer.Core.Entities;

namespace NLayer.Core.Repositories
{
    public interface IBankaRepository : IGenericRepository<Banka>
    {
        Task<List<Banka>> GetBankalarWithSube();
    }
}