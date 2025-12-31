using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public static class Extensions
    {
        public static IServiceCollection AddData(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddDbContext<AppContext>(x =>
            {
                x.UseNpgsql("Host=localhost;Database=AccountsDb;Username=postgres;Password=1234");
            });
            return serviceCollection;
        }
    }
}
