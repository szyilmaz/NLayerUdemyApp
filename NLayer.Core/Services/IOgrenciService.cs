using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface IOgrenciService : IService<Ogrenci>
    {
        Task<List<OgrenciWithDersDto>> GetOgrenciWithDers();
        Task<List<OgrenciWithDersDto>> GetOgrenciWithDers(OgrenciFilterDto filter);
        Task AddDersToOgrenci(OgrenciDersSaveDto dto);
        Task UpdateOgrenciWithDers(OgrenciUpdateWithDersDto dto);

    }
}
