using System.ComponentModel.DataAnnotations;

namespace TransactionRepository.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; }                                 
        public DateTime RegistrationTime { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
