using System.Text.Json.Serialization;

namespace E_CommerceStore.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }
        [JsonIgnore] 
        public Payment Payment { get; set; }
    }
}
