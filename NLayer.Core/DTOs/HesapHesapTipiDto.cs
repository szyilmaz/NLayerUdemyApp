using NLayer.Core.Entities;

namespace NLayer.Core.DTOs
{
    public class HesapHesapTipiDto 
    {
        public int HesapTipiId { get; set; }
        public HesapTipiDto HesapTipi { get; set; }

        public int HesapId { get; set; }
        public HesapDto Hesap { get; set; }
    }
}
