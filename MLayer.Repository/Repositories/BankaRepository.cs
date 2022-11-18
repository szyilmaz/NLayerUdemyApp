using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Repository.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NLayer.Repository.Repositories
{
    public class BankaRepository : GenericRepository<Banka>, IBankaRepository
    {
        public BankaRepository(AppDbContext context) : base(context)
        {

        }

        public IQueryable<DetailedHareket> GetHareketler()
        {
            var query = from b in _context.Bankalar
                         join s in _context.Subeler
                         on b.Id equals s.BankaId
                         join h in _context.Hesaplar.Include(ht => ht.HesapTipleri).ThenInclude(x => x.HesapTipi)
                         on s.Id equals h.SubeId
                         join m in _context.Musteriler
                         on h.MusteriId equals m.Id
                         join l in _context.Lokasyonlar
                         on s.LokasyonId equals l.Id
                         join hrk in _context.Hareketler
                         on h.Id equals hrk.HesapId
                         select new DetailedHareket
                         {
                             BankaId = b.Id,
                             BankaAdi = b.Adi,
                             SubeId = s.Id,
                             SubeAdi = s.Adi,
                             SubeTipiId = s.SubeTipiId,
                             SubeTipiAdi = s.SubeTipi.Adi,
                             HesapId = h.Id,
                             HesapKodu = h.Kodu,
                             HesapTipleri = h.HesapTipleri,
                             DovizTipiId = h.DovizTipiId,
                             DovizTipiAdi = h.DovizTipi.Adi,
                             MusteriId = m.Id,
                             MusteriAdi = m.AdiSoyadi,
                             LokasyonId = l.Id,
                             LokasyonAdi = l.Adi,
                             HareketId = hrk.Id,
                             HareketTipId = hrk.HareketTipiId,
                             HareketTipAdi = hrk.HareketTipi.Adi,
                             Tutar = hrk.Tutar,
                             Aciklama = hrk.Aciklama,
                             HareketTarihi = hrk.Tarih
                         };

            return query;
        }

        public IQueryable<DetailedHareket> GetHareketler2()
        {
            var query = from b in _context.Bankalar
                        join s in _context.Subeler
                        on b.Id equals s.BankaId
                        join h in _context.Hesaplar.Include(c=>c.HesapTipleri)
                        on s.Id equals h.SubeId
                        join hts in _context.HesapHesapTipleri
                        on h.Id equals hts.HesapId
                        join ht in _context.HesapTipleri
                        on hts.HesapTipiId equals ht.Id
                        join m in _context.Musteriler
                        on h.MusteriId equals m.Id
                        join l in _context.Lokasyonlar
                        on s.LokasyonId equals l.Id
                        join hrk in _context.Hareketler
                        on h.Id equals hrk.HesapId
                        select new DetailedHareket
                        {
                            BankaId = b.Id,
                            BankaAdi = b.Adi,
                            SubeId = s.Id,
                            SubeAdi = s.Adi,
                            SubeTipiId = s.SubeTipiId,
                            SubeTipiAdi = s.SubeTipi.Adi,
                            HesapId = h.Id,
                            HesapKodu = h.Kodu,
                            HesapTipleri = h.HesapTipleri,
                            HesapTipiId = ht.Id,
                            HesapTipiAdi = ht.Adi,
                            DovizTipiId = h.DovizTipiId,
                            DovizTipiAdi = h.DovizTipi.Adi,
                            MusteriId = m.Id,
                            MusteriAdi = m.AdiSoyadi,
                            LokasyonId = l.Id,
                            LokasyonAdi = l.Adi,
                            HareketId = hrk.Id,
                            HareketTipId = hrk.HareketTipiId,
                            HareketTipAdi = hrk.HareketTipi.Adi,
                            Tutar = hrk.Tutar,
                            Aciklama = hrk.Aciklama,
                            HareketTarihi = hrk.Tarih
                        };

            return query;
        }


    }
}
