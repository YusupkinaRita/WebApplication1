using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{


    internal class AccountRepository(AppContext context) : IAccountRepository
    {
        public async Task CreateAsync(Account account, CancellationToken cancellationToken = default)
        {
            await context.Accounts.AddAsync(account, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Account?> GetByLoginAsync(string login, CancellationToken cancellationToken = default)
        {
            return await context.Accounts
                .FirstOrDefaultAsync(a => a.Login == login, cancellationToken);
        }

        public async Task<bool> DeleteByLoginAsync(string login, CancellationToken cancellationToken = default)
        {
            var account = await GetByLoginAsync(login, cancellationToken);

            if (account == null)
            {
                return false;
            }

         
            context.Accounts.Remove(account);
            await context.SaveChangesAsync(cancellationToken);

            return true; // ← Аккаунт успешно удалён
        }
    }
}
