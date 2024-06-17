namespace LibraryManagementSystem.Dto
{
    public class BookCopyDto
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }

        public int CopyNumber { get; set; }
        public string Condition { get; set; }
    }
}
