using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.DTOs;
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
            var query = from b in _context.Bankalar
                        join s in _context.Subeler
                        on b.Id equals s.BankaId
                        join h in _context.Hesaplar
                        on s.Id equals h.SubeId
                        join m in _context.Musteriler
                        on h.MusteriId equals m.Id
                        select new 
                        {
                            BankaId = b.Id,
                            BankaAdi = b.Adi,
                            SubeId = s.Id, 
                            SubeAdi = s.Adi, 
                            HesapId = h.Id, 
                            HesapKodu = h.Kodu, 
                            MusteriId = m.Id, 
                            MusteriAdi = m.AdiSoyadi 
                        };

            var queryList = query.ToList();
                        
            var bankalar = await _context.Bankalar
                .Include(x => x.Subeler)
                .ThenInclude(c => c.Hesaplar)
                .ToListAsync();

            return bankalar;
        }
    }
}
