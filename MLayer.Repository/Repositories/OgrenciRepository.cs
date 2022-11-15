using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NLayer.Core;
using NLayer.Core.DTOs;
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

        public async Task<List<Ogrenci>> GetOgrenciWithDers(OgrenciFilterDto filter)
        {
            IQueryable<Ogrenci> ogrencis = _context.Ogrenciler.OrderBy(c=>c.Adi).Include(x => x.OgrenciDersleri).ThenInclude(y => y.Ders);

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                ogrencis = ogrencis.Where(c => c.Adi.ToLower().Contains(filter.Keyword.ToLower()) || c.Soyadi.ToLower().Contains(filter.Keyword.ToLower()));
            }

            if (filter.Dersler != null && filter.Dersler.Count > 0 && filter.Dersler.Where(c => c.Checked).Count() > 0)
            {
                var filteredDersler = filter.Dersler.Where(c => c.Checked).Select(c => c.Id).ToList();

                //ogrencis = ogrencis.Where(c => c.OgrenciDersleri.Any(l => filteredDersler.Contains(l.DersId)));

                foreach (var item in filteredDersler)
                {
                    ogrencis = ogrencis.Where(c => c.OgrenciDersleri.Any(d=>d.DersId == item));
                }
            }

            if (!string.IsNullOrEmpty(filter.SortOrder))
            {
                switch (filter.SortOrder)
                {
                    case "name_desc":
                        ogrencis = ogrencis.OrderByDescending(s => s.Adi);
                        break;
                    case "Surname":
                        ogrencis = ogrencis.OrderBy(s => s.Soyadi);
                        break;
                    case "surname_desc":
                        ogrencis = ogrencis.OrderByDescending(s => s.Soyadi);
                        break;
                    default:
                        ogrencis = ogrencis.OrderBy(s => s.Adi);
                        break;
                }
            }

            var sonuc = await ogrencis.ToListAsync();

            return sonuc;
        }

        public async Task<Ogrenci> GetOgrenciWithDers(int Id)
        {
            var sonuc = await _context.Ogrenciler.Where(c=> c.Id == Id).Include(x => x.OgrenciDersleri).ThenInclude(y => y.Ders).FirstOrDefaultAsync();

            return sonuc;
        }
    }
}