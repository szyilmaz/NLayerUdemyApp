using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Hareket : BankAppBaseEntity
    {
        public int HesapId { get; set; }
        public int HareketTipiId { get; set; }
        public HareketTipi HareketTipi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
