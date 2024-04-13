using System.ComponentModel.DataAnnotations;

namespace TransactionRepository.Model
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public DateTime OpeningDate { get; set; }

    }
}

