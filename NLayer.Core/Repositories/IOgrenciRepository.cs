using NLayer.Core.DTOs;

namespace NLayer.Core.Repositories
{
    public interface IOgrenciRepository : IGenericRepository<Ogrenci>
    {
        Task<List<Ogrenci>> GetOgrenciWithDers();
        Task<List<Ogrenci>> GetOgrenciWithDers(OgrenciFilterDto filter);
        Task<Ogrenci> GetOgrenciWithDers(int Id);
    }
}