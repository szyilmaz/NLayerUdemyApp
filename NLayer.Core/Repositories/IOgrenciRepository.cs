namespace NLayer.Core.Repositories
{
    public interface IOgrenciRepository : IGenericRepository<Ogrenci>
    {
        Task<List<Ogrenci>> GetOgrenciWithDers();
        Task<Ogrenci> GetOgrenciWithDers(int Id);
    }
}