using SimpleLogin.Ui.Services;

namespace BookStore.Services
{
    public class BookAuthService : ISimpleLoginAuth
    {
        public Task<bool> ValidateUserAsync(string username, string password)
        {
            // Simple mock authentication for the book store
            // User: reader, Pass: books123
            if (username.ToLower() == "reader" && password == "books123")
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
