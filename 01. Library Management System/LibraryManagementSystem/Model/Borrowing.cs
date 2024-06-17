using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class Borrowing
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        [JsonIgnore]
        public Member Member { get; set; }

        public int BookCopyId { get; set; }
        [JsonIgnore]
        public BookCopy BookCopy { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        [JsonIgnore]
        public Fine Fine { get; set; }
    }
}
