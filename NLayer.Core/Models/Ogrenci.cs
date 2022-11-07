namespace NLayer.Core
{
    public class Ogrenci : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public IList<OgrenciDers> OgrenciDersleri { get; set; }
    }
}