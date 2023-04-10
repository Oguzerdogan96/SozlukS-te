namespace XSözlük.WEBUI.Models
{
    public class HomeListViewModel
    {
        public int TitleId { get; set; }
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Entry { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Sayi { get; set; }
    }
}
