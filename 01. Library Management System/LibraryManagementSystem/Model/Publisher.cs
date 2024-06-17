using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
