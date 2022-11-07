namespace NLayer.Core.DTOs
{
    public class OgrenciWithDersDto : BaseDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public IList<OgrenciDersDto> OgrenciDersleri { get; set; }
    }
}