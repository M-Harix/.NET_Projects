using System.Text.Json.Serialization;

namespace BankManagementSystem.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public ICollection<Customer> Customers { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
