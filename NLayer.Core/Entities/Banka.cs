using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public  class Banka : BankAppBaseEntity
    {
        public string Adi { get; set; }
        public List<Sube> Subeler { get; set; }
    }
}
