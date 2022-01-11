using Domain.Entities;

namespace Domain.Services.Infrastructure;

public interface IUserService
{
    Task<User> FindUserByIdAsync(int userId);
}

