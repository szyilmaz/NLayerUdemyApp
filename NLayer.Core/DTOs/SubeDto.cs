using NLayer.Core.Entities;

namespace NLayer.Core.DTOs
{
    public class SubeDto : BankAppBaseDto
    {
        public string Adi { get; set; }
        public List<HesapDto> Hesaplar { get; set; }
    }
}
