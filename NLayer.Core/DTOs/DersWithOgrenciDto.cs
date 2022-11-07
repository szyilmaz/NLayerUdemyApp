namespace NLayer.Core.DTOs
{
    public class DersWithOgrenciDto : BaseDto
    {
        public string Adi { get; set; }
        public IList<DersOgrenciDto> DersOgrencileri { get; set; }
    }
}