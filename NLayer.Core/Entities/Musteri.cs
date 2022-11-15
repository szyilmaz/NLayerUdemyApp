using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Musteri : BankAppBaseEntity
    {
        public string AdiSoyadi { get; set; }
        public MusteriTipi MusteriTipi { get; set; }
        public List<Hesap> Hesaplar { get; set; }
    }
}