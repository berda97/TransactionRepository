namespace TransactionRepository.Model
{
    public class Account
    {
        public int AccountId { get; set; } 
        public int UserId { get; set; } 
        public decimal Balance { get; set; } 
        public DateTime OpeningDate { get; set; }
    }
}
