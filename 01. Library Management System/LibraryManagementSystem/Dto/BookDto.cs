namespace LibraryManagementSystem.Dto
{
    public class BookDto
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        
        public int AuthorId { get; set; }

        public int PublisherId { get; set; }
        
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
