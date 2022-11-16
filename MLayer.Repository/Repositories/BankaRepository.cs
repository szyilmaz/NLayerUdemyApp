using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class BankaRepository : GenericRepository<Banka>, IBankaRepository
    {
        public BankaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Banka>> GetBankalarWithSube()
        {
            return await _context.Bankalar.Include(x => x.Subeler).ThenInclude(c=>c.Hesaplar).ThenInclude(c=>c.Hareketler).ThenInclude(c => c.HareketTipi).ToListAsync();
        }
    }
}
