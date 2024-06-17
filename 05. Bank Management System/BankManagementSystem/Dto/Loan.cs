namespace BankManagementSystem.Dto
{
    public class LoanDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }        
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public DateTime StartDate { get; set; }
    }
}
