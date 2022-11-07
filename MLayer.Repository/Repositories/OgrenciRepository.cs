using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class OgrenciRepository : GenericRepository<Ogrenci>, IOgrenciRepository
    {
        public OgrenciRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Ogrenci>> GetOgrenciWithDers()
        {
            var sonuc = await _context.Ogrenciler.Include(x => x.OgrenciDersleri).ThenInclude(y => y.Ders).ToListAsync();

            return sonuc;
        }

        public async Task<Ogrenci> GetOgrenciWithDers(int Id)
        {
            var sonuc = await _context.Ogrenciler.Where(c=> c.Id == Id).Include(x => x.OgrenciDersleri).ThenInclude(y => y.Ders).FirstOrDefaultAsync();

            return sonuc;
        }
    }
}