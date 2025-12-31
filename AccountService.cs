using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class AccountService(IAccountRepository accountRepository, JWTService jwtService):IAccountService
    {
        public async Task RegisterAsync(string login, string name, string password, CancellationToken cancellationToken = default)
        {
          
            var existingAccount = await accountRepository.GetByLoginAsync(login);
            if (existingAccount != null)
            {
                throw new Exception("Login already exists");
            }

            Account account = new Account
            {
                Login = login,
                Name = name,
                Id = Guid.NewGuid()
            };
            var passHash = new PasswordHasher<Account>().HashPassword(account, password);
            account.PasswordHash = passHash;

            await accountRepository.CreateAsync(account);

        }
        public async Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken = default)
        {
            var account = await accountRepository.GetByLoginAsync(login);

            if (account == null)
            {
                throw new Exception("Account not found");
            }

            // Проверяем пароль
            var verificationResult = new PasswordHasher<Account>().VerifyHashedPassword(account, account.PasswordHash, password);

            if (verificationResult == PasswordVerificationResult.Success)
            {
                return jwtService.GenerateToken(account);
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }

        //public void Register(string login, string name, string password)
        //{
        //    Account account = new Account
        //    {
        //        Login = login,
        //        Name = name,
        //        Id = Guid.NewGuid()
        //    };
        //    var passHash = new PasswordHasher<Account>().HashPassword(account, password);
        //    account.PasswordHash = passHash;

        //    accountBase.Add(account);



        //}

        //public string Login(string login, string password)
        //{
        //    var account = accountBase.GetByLogin(login);

        //    if (account == null)
        //    {
        //        throw new Exception("Account not found");
        //    }
        //    var verification_result =new PasswordHasher<Account>().VerifyHashedPassword(account, account.PasswordHash,password);
        //    if (verification_result == PasswordVerificationResult.Success)
        //    {
        //        return jwtService.GenerateToken(account);

        //    }
        //    else
        //    {
        //        throw new Exception("unauthorised");
        //    }

        //}
    }
}
