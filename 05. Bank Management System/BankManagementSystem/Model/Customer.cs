using System.Security.Principal;
using System.Text.Json.Serialization;

namespace BankManagementSystem.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int BranchID { get; set; }
        [JsonIgnore]
        public Branch Branch { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public ICollection<Loan> Loans { get; set; }
    }

}
