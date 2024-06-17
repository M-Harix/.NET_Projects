using System.Text.Json.Serialization;

namespace BankManagementSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public int BranchID { get; set; }
        [JsonIgnore]
        public Branch Branch { get; set; }
    }
}
