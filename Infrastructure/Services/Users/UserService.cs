using Domain.Entities;
using Domain.Services.Infrastructure;

namespace Infrastructure.Services.Users;

public class UserService : IUserService
{

    public Task<User> FindUserByIdAsync(int userId)
    {
        var user = new User
        {
            Id = 123456,
            Name = "Test user",
        };

        return Task.FromResult(user);
    }
}