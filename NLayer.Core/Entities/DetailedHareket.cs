using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class DetailedHareket
    {
        public int BankaId { get; set; }
        public string BankaAdi { get; set; }
        public int SubeId { get; set; }
        public string SubeAdi { get; set; }
        public int SubeTipiId { get; set; }
        public string SubeTipiAdi { get; set; }
        public int HesapId { get; set; }
        public string HesapKodu { get; set; }
        public List<HesapTipi> HesapTipleri { get; set; }
        public int DovizTipiId { get; set; }
        public string DovizTipiAdi { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public int LokasyonId { get; set; }
        public string LokasyonAdi { get; set; }
        public int HareketId { get; set; }
        public int HareketTipId { get; set; }
        public string HareketTipAdi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public DateTime HareketTarihi { get; set; }
    }
}


/*
BankaId = b.Id,
BankaAdi = b.Adi,
SubeId = s.Id, 
SubeAdi = s.Adi, 
SubeTipiId = st.Id,
SubeTipiAdi = st.Adi,
HesapId = h.Id, 
HesapKodu = h.Kodu,
HesapTipleri = h.HesapTipleri,
DovizTipiId = d.Id,
DovizTipiAdi = d.Adi,
MusteriId = m.Id, 
MusteriAdi = m.AdiSoyadi, 
LokasyonId = l.Id,
LokasyonAdi = l.Adi,
HareketId = hrk.Id,
HareketTip = hrk.HareketTipiId,
Tutar = hrk.Tutar
*/