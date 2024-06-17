using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Model
{
    public class Fine
    {
        public int FineID { get; set; }

        public int BorrowingId { get; set; }
        [JsonIgnore]
        public Borrowing Borrowing { get; set; }

        public decimal Amount { get; set; }
        public bool Paid { get; set; }
    }
}
