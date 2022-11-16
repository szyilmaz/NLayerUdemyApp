using NLayer.Core.Entities;

namespace NLayer.Core.DTOs
{
    public class HesapDto : BankAppBaseDto
    {
        public string Kodu { get; set; }
        public MusteriDto Musteri { get; set; }
        public ICollection<HareketDto> Hareketler { get; set; }
    }
}
