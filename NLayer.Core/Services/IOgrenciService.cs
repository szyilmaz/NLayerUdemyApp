using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface IOgrenciService : IService<Ogrenci>
    {
        Task<List<OgrenciWithDersDto>> GetOgrenciWithDers();
        Task AddDersToOgrenci(OgrenciDersSaveDto dto);
        Task UpdateOgrenciWithDers(OgrenciUpdateWithDersDto dto);

    }
}
