using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Sube : BankAppBaseEntity
    {
        public string Adi { get; set; }
        public Lokasyon Lokasyon { get; set; }
        public SubeTipi SubeTipi { get; set; }
        public List<Hesap> Hesaplar { get; set; }
    }
}
