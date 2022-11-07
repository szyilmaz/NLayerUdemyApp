namespace NLayer.Core.DTOs
{
    public class OgrenciDersDto : BaseDto
    {
        public int OgrenciId { get; set; }
        public int DersId { get; set; }
        public DersDto Ders { get; set; }
    }
}