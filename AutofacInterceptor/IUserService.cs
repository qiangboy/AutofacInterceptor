namespace AutofacInterceptor;

public interface IUserService
{
    Task<string> GetUserByIdAsync(int id);
    bool IsActive(int id);
    Task StartAsync();
}