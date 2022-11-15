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
        public HesapTipi HesapTipi { get; set; }
        public DovizTipi DovizTipi { get; set; }
        public List<Hareket> Hareketler { get; set; }
    }
}
