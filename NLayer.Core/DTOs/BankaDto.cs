namespace NLayer.Core.DTOs
{
    public class BankaDto : BankAppBaseDto
    {
        public string Adi { get; set; }
        public ICollection<SubeDto> Subeler { get; set; }
    }
}
