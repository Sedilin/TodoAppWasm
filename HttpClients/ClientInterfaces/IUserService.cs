using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
}