using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Hesap : BankAppBaseEntity
    {
        public string Kodu { get; set; }
        public List<HesapTipi> HesapTipleri { get; set; }
        public int DovizTipiId { get; set; }
        public DovizTipi DovizTipi { get; set; }
        public List<Hareket> Hareketler { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public int SubeId { get; set; }
        public Sube Sube { get; set; }
    }
}
