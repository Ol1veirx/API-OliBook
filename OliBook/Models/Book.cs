namespace OliBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public bool WasRead { get; set; }
    }
}
