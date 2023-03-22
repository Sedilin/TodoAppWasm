using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface ITodoService
{
    Task CreateAsync(TodoCreationDto dto);
    Task<ICollection<Todo>> GetAsync(string? username, int? userId, bool? completedStatus, string? titleContains);
}