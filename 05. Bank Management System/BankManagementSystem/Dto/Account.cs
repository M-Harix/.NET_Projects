namespace BankManagementSystem.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public int CustomerID { get; set; }
    }

}
