namespace AutofacInterceptor;

public class UserService : IUserService
{
    public async Task<string> GetUserByIdAsync(int id)
    {
        await Task.Delay(100);

        return $"User Id = {id}";
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