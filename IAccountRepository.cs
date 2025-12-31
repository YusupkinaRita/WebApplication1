using Microsoft.EntityFrameworkCore;
namespace WebApplication1
{
    public interface IAccountRepository
    {
        Task CreateAsync(Account account, CancellationToken cancellationToken = default);
        Task<Account?> GetByLoginAsync(string login, CancellationToken cancellationToken = default);
        Task<bool> DeleteByLoginAsync(string login, CancellationToken cancellationToken = default);
    }
}
