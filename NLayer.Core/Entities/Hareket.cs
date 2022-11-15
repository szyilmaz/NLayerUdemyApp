using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Hareket : BankAppBaseEntity
    {
        public HareketTipi HareketTipi { get; set; }
        public decimal Tutar { get; set; }
    }
}
