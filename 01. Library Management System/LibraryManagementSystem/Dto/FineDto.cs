namespace LibraryManagementSystem.Dto
{
    public class FineDto
    {
        public int FineID { get; set; }

        public int BorrowingId { get; set; }

        public decimal Amount { get; set; }
        public bool Paid { get; set; }
    }
}
