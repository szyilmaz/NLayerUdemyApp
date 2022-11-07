namespace NLayer.Core.Repositories
{
    public interface IDersRepository : IGenericRepository<Ders>
    {
        Task<List<Ders>> GetDersWithOgrenci();
    }
}
