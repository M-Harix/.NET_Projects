using System.Text.Json.Serialization;

namespace E_CommerceStore.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}
