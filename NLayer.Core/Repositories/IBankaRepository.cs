using NLayer.Core.Entities;

namespace NLayer.Core.Repositories
{
    public interface IBankaRepository : IGenericRepository<Banka>
    {
        IQueryable<DetailedHareket> GetHareketler();
        IQueryable<DetailedHareket> GetHareketler2();
    }
}