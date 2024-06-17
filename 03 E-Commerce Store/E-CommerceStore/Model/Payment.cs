using System.Text.Json.Serialization;

namespace E_CommerceStore.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}
