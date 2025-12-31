using Microsoft.EntityFrameworkCore;
namespace WebApplication1
{
    public interface IAccountService
    {
        Task RegisterAsync(string login, string name, string password, CancellationToken cancellationToken = default);
        Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken = default);
    }
}
