using NLayer.Core.Entities;

namespace NLayer.Core.DTOs
{
    public class MusteriDto : BankAppBaseDto
    {
        public string AdiSoyadi { get; set; }
        public MusteriTipi MusteriTipi { get; set; }
        public List<HesapDto> Hesaplar { get; set; }
    }
}
