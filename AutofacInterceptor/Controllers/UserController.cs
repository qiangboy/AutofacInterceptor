using Microsoft.AspNetCore.Mvc;

namespace AutofacInterceptor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public Task<string> GetUserById(int id)
    {
        return userService.GetUserByIdAsync(id);
    }

    [HttpGet(nameof(IsActive))]
    public bool IsActive(int id)
    {
        return userService.IsActive(id);
    }

    [HttpPost]
    public async Task<ActionResult> Start()
    {
        await userService.StartAsync();

        return Ok();
    }
}