namespace NLayer.Core.DTOs
{
    public class DersOgrenciDto : BaseDto
    {
        public int OgrenciId { get; set; }
        public int DersId { get; set; }
        public OgrenciDto Ogrenci { get; set; }
    }
}