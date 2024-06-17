using System.Text.Json.Serialization;

namespace BankManagementSystem.Model
{
    public class Transaction
    {
        public int Id { get; set; }

        public int AccountID { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
