namespace AutofacInterceptor;

public class UserService : IUserService
{
    public Task<string> GetUserByIdAsync(int id)
    {
        return Task.FromResult($"User Id = {id}");
    }

    public bool IsActive(int id)
    {
        return id > 10;
    }

    public Task StartAsync()
    {
        return Task.CompletedTask;
    }
}