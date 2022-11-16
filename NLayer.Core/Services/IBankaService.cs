using NLayer.Core.DTOs;
using NLayer.Core.Entities;

namespace NLayer.Core.Services
{
    public interface IBankaService : IService<Banka>
    {
        Task<List<BankaDto>> GetBankalarWithSube();
    }
}
