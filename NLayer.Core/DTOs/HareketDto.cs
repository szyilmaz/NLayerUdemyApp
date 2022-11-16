namespace NLayer.Core.DTOs
{
    public class HareketDto : BankAppBaseDto
    {
        public HareketTipiDto HareketTipi { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
