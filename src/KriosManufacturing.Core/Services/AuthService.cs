namespace KriosManufacturing.Core.Services;

using Models;
using BCrypt.Net;
public class AuthService
{
    public Task<bool> AuthenticateAsync(string email, string password, CancellationToken ctok)
    {
        var account = new Account
        {
            User = new User
            {
                Email = "test@example.com",
                Name = "test",
            },
            Password = "asdf123",
        };
        return Task.FromResult(password == account.Password);
    }
}
