using System.Text.Json.Serialization;

namespace E_CommerceStore.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
