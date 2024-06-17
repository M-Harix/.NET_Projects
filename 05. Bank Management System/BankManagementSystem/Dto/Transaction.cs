namespace BankManagementSystem.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
