using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{

    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;
        
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? result = null;
        foreach (User user in context.Users)
        {
            if (user.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(user);
            }
        }
        return Task.FromResult(result);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.UserName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? result = null;
        foreach (var user in context.Users)
        {
            if (user.Id == id)
            {
                return Task.FromResult(user);
            }
        }
        return Task.FromResult(result);
    }
}