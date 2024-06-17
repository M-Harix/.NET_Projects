namespace LibraryManagementSystem.Dto
{
    public class BorrowingDto
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int BookCopyId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
    }
}
