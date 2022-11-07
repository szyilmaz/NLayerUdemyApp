namespace NLayer.Core
{
    public class OgrenciDers : BaseEntity
    {
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }

        public int DersId { get; set; }
        public Ders Ders { get; set; }
    }
}