using System.Text.Json.Serialization;

namespace E_CommerceStore.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
