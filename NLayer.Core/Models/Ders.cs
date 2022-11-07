namespace NLayer.Core
{
    public class Ders : BaseEntity
    {
        public string Adi { get; set; }
        public IList<OgrenciDers> DersOgrencileri { get; set; }
    }
}