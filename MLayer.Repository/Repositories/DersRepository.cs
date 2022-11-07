using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class DersRepository : GenericRepository<Ders>, IDersRepository
    {
        public DersRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Ders>> GetDersWithOgrenci()
        {
            var sonuc = await _context.Dersler.Include(x => x.DersOgrencileri).ThenInclude(y => y.Ogrenci).ToListAsync();

            return sonuc;
        }
    }
}
