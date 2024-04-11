using System.Security.Cryptography;
using System.Text;
using TransactionRepository.Interface;

namespace TransactionRepository.Service
{
    public class HashService : IHashService
    { 
        public bool IsValidHash(string receivedHash, string data, string secretKey)
        {
            string calculatedHash = CalculateHash(data, secretKey);
            return receivedHash == calculatedHash;
        }
        private string CalculateHash(string data, string secretKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data + secretKey);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
