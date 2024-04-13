using TransactionRepository.Model;

namespace TransactionRepository.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(TransactionDatabaseContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                new User {  UserId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Password = "password", RegistrationTime = DateTime.Now, AccountId = 1 },
                new User {  UserId = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", Password = "password",  RegistrationTime = DateTime.Now, AccountId = 2 },
                new User {  UserId = 3, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Password = "password",  RegistrationTime = DateTime.Now, AccountId = 3 },
                new User {  UserId = 4, FirstName = "Bob", LastName = "Jones", Email = "bob@example.com", Password = "password",  RegistrationTime = DateTime.Now, AccountId = 4 },
                new User {  UserId = 5, FirstName = "Emily", LastName = "Brown", Email = "emily@example.com", Password = "password",  RegistrationTime = DateTime.Now, AccountId=5 }
             );
                await context.SaveChangesAsync();
            }
        }
    }
}
