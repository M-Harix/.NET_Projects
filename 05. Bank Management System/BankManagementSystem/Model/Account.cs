using System.Text.Json.Serialization;
using System.Transactions;

namespace BankManagementSystem.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        public int CustomerID { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }
    }

}
