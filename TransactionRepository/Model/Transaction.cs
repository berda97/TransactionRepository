using System.ComponentModel.DataAnnotations;

namespace TransactionRepository.Model
{
    public class Transaction 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid TransactionId { get; set; }
        
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
