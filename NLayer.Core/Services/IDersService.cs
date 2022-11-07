using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface IDersService : IService<Ders>
    {
        Task<List<DersWithOgrenciDto>> GetDersWithOgrenci();
    }
}
