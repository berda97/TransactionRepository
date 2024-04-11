namespace TransactionRepository.Interface
{
    public interface IHashService
    {
        bool IsValidHash(string receivedHash, string data, string secretKey);
    }

}
