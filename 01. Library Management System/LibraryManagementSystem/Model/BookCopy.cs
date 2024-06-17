using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class BookCopy
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }

        public int CopyNumber { get; set; }
        public string Condition { get; set; }
        [JsonIgnore]
        public Borrowing Borrowing { get; set; }
    }
}
