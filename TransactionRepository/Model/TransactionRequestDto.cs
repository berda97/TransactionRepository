namespace TransactionRepository.Model
{
    public class TransactionRequestDto
    {
        public string ExternalTransactionId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
