using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class HesapHesapTipi
    {
        public int HesapTipiId { get; set; }
        public HesapTipi HesapTipi { get; set; }

        public int HesapId { get; set; }
        public Hesap Hesap { get; set; }
    }
}
