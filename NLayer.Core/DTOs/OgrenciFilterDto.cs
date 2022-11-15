namespace NLayer.Core.DTOs
{
    public class OgrenciFilterDto
    {
        public string Keyword { get; set; }
        public string SortOrder { get; set; }
        public List<DersCheckedDto> Dersler { get; set; }
    }
}
