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
                new User { Id = Guid.NewGuid(), UserId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", Password = "password", RegistrationTime = DateTime.Now },
                new User { Id = Guid.NewGuid(), UserId = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", Password = "password",  RegistrationTime = DateTime.Now },
                new User { Id = Guid.NewGuid(), UserId = 3, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Password = "password",  RegistrationTime = DateTime.Now },
                new User { Id = Guid.NewGuid(), UserId = 4, FirstName = "Bob", LastName = "Jones", Email = "bob@example.com", Password = "password",  RegistrationTime = DateTime.Now },
                new User { Id = Guid.NewGuid(), UserId = 5, FirstName = "Emily", LastName = "Brown", Email = "emily@example.com", Password = "password",  RegistrationTime = DateTime.Now }
             );
                await context.SaveChangesAsync();
            }
        }
    }
}
