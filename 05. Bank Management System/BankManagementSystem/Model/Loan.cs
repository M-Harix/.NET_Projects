using System.Text.Json.Serialization;

namespace BankManagementSystem.Model
{
    public class Loan
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public DateTime StartDate { get; set; }
    }
}
