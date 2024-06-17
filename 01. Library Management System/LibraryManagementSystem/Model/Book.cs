using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        [JsonIgnore]
        public Publisher Publisher { get; set; }
        
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
