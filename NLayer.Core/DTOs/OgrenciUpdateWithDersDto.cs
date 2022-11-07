namespace NLayer.Core.DTOs
{
    public class OgrenciUpdateWithDersDto
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public List<DersCheckedDto> Dersler { get; set; }
    }
}
